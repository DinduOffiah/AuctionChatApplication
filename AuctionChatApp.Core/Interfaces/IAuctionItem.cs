using AuctionChatApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Interfaces
{
    public interface IAuctionItem
    {
        Task<IEnumerable<AuctionItem>> GetItemAsync();
        Task<AuctionItem> GetItemByIdAsync(int id);
        Task<AuctionItem> CreateItemAsync(AuctionItem events);
        Task UpdateItemAsync(AuctionItem events);
        Task DeleteItemAsync(int id);
    }
}
