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
    public class PaymentService : IPaymentService
    {
        private readonly AuctionChatAppDbContext _context;

        public PaymentService(AuctionChatAppDbContext context)
        {
            _context = context;
        }
        public async Task<Bid> GetHighestBidderAsync()
        {
            //TODO: This should get the Username as well.
            return await _context.Bids.OrderByDescending(bid => bid.Amount).FirstOrDefaultAsync();
        }

        public async Task MakePaymentAsync()
        {

        }
    }
}
