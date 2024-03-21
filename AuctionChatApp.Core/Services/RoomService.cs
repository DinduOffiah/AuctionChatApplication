using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Data;
using AuctionChatApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly AuctionChatAppDbContext _context;

        public RoomService(AuctionChatAppDbContext context)
        {
            _context = context;
        }

        public async Task StopAuctionAsync(string itemUniqueNumber)
        {
            var item = await _context.AuctionItems.FirstOrDefaultAsync(i => i.ItemUniqueNumber == itemUniqueNumber);
            if (item == null)
            {
                throw new Exception("Item not found.");
            }

            item.IsAvailableForAuction = false;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuctionItem>> GetAuctionedItemsAsync()
        {
            return await _context.AuctionItems
                .Where(item => item.IsAvailableForAuction)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetBidsAsync()
        {
            return await _context.Bids.OrderByDescending(bid => bid.Amount).ToListAsync();
        }

        public async Task StartAuctionAsync()
        {
            var auctionedItems = await GetAuctionedItemsAsync();

            if (auctionedItems.Any())
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "biddingQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = "Start Bidding Process";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "biddingQueue",
                                         basicProperties: null,
                                         body: body);
                }
            }
            else
            {
                throw new Exception("No items available for auction.");
            }

        }

        public async Task<Bid> GetHighestBidAsync()
        {
            //TODO: This should get the Username as well.
            return await _context.Bids.OrderByDescending(bid => bid.Amount).FirstOrDefaultAsync();
        }

    }
}
