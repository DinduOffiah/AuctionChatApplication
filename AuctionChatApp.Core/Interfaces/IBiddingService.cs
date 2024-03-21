using AuctionChatApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Interfaces
{
    public interface IBiddingService
    {

        Task<Bid> MakeBidAsync(Bid bid);
        Task<AuctionItem> GetItemByUniqueNumberAsync(string uniqueNumber);
    }
}
