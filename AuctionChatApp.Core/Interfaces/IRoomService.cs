using AuctionChatApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<AuctionItem>> GetAuctionedItemsAsync();
        Task<IEnumerable<Bid>> GetBidsAsync();
        Task StartAuctionAsync();
        Task StopAuctionAsync(string itemUniqueNumber);
        Task<Bid> GetHighestBidAsync();
    }
}
