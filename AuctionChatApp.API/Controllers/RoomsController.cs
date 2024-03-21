using AuctionChatApp.Core.DTOs;
using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(IRoomService roomService, ILogger<RoomsController> logger)
        {
            _roomService = roomService;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of auctioned items.
        /// </summary>
        /// <returns>Returns a list of auctioned items.</returns>
        // GET: api/AuctionedItems
        [HttpGet("AuctionedItems")]
        public async Task<ActionResult<IEnumerable<ReadAuctionItemDto>>> GetAuctionedItems()
        {
            try
            {
                var items = await _roomService.GetAuctionedItemsAsync();

                if (items == null || !items.Any())
                {
                    return NotFound("No auctioned item found.");
                }

                var itemDtos = items.Select(e => new ReadAuctionItemDto
                {
                    ItemName = e.ItemName,
                    Description = e.Description,
                    Quantity = e.Quantity,
                    ItemUniqueNumber = e.ItemUniqueNumber,
                    IsAvailableForAuction = e.IsAvailableForAuction,
                    StopTime = e.StopTime,
                }).ToList();

                return Ok(itemDtos);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging purposes
                _logger.LogError(ex, "An error occurred while getting auctioned items.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// Retrieves a list of bids.
        /// </summary>
        /// <returns>Returns a list of bids.</returns>
        // GET: api/Bids
        [HttpGet("Bids")]
        public async Task<ActionResult<IEnumerable<BidDto>>> GetBids()
        {
            try
            {
                var items = await _roomService.GetBidsAsync();

                if (items == null || !items.Any())
                {
                    return NotFound("No Bid found.");
                }

                var itemDtos = items.Select(e => new BidDto
                {
                    Amount = e.Amount,
                    ItemUniqueNumber = e.ItemUniqueNumber,
                }).ToList();

                return Ok(itemDtos);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging purposes
                _logger.LogError(ex, "An error occurred while getting auctioned items.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }


        /// <summary>
        /// Retrieves a list of bids.
        /// </summary>
        /// <returns>Returns a list of bids.</returns>
        // GET: api/Rooms/HighestBid
        [HttpGet("HighestBid")]
        public async Task<ActionResult<Bid>> GetHighestBid()
        {
            try
            {
                var highestBid = await _roomService.GetHighestBidAsync();

                if (highestBid == null)
                {
                    return NotFound("No bids found.");
                }

                return Ok(highestBid);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging purposes
                _logger.LogError(ex, "An error occurred while getting the highest bid.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

    }
}
