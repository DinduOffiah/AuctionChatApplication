using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Data;
using AuctionChatApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Services
{
    public class BiddingService : IBiddingService
    {
        private readonly AuctionChatAppDbContext _context;

        public BiddingService(AuctionChatAppDbContext context)
        {
            _context = context;
        }

        public async Task<AuctionItem?> GetItemByUniqueNumberAsync(string uniqueNumber)
        {
            return await _context.AuctionItems
                .FirstOrDefaultAsync(item => item.ItemUniqueNumber == uniqueNumber);
        }

        public async Task<Bid> MakeBidAsync(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
            return bid;
        }
    }
}
