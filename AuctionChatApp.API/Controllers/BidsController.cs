using AuctionChatApp.Core.DTOs;
using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace AuctionChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidsController : ControllerBase
    {
        private readonly IBiddingService _biddingService;
        private readonly ILogger<BidsController> _logger;

        public BidsController(IBiddingService biddingService, ILogger<BidsController> logger)
        {
            _biddingService = biddingService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new bid.
        /// </summary>
        /// <param name="bidDto">The bid information.</param>
        /// <returns>Returns the created bid.</returns>
        // POST: api/Bid
        [HttpPost]
        public async Task<ActionResult<Bid>> SubmitBid(BidDto bidDto)
        {
            try
            {
                // Fetch item details based on unique number
                var item = await _biddingService.GetItemByUniqueNumberAsync(bidDto.ItemUniqueNumber);
                if (item == null)
                {
                    return BadRequest("Invalid ItemUniqueNumber.");
                }

                // Check if the auction has ended
                if (!item.IsAvailableForAuction || DateTime.Now > item.StopTime)
                {
                    return BadRequest("The auction has ended.");
                }

                // Create bid
                var bid = new Bid
                {
                    ItemUniqueNumber = item.ItemUniqueNumber,
                    Amount = bidDto.Amount
                };

                var createdBid = await _biddingService.MakeBidAsync(bid);

                // Publish message to RabbitMQ
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "notificationQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = $"New bid of {bid.Amount} for item {item.ItemUniqueNumber}";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "notificationQueue",
                                         basicProperties: null,
                                         body: body);
                }

                return CreatedAtAction(nameof(SubmitBid), new { id = createdBid.Id }, createdBid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a bid.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

    }
}
