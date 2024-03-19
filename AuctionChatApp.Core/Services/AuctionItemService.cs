using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Data;
using AuctionChatApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionChatApp.Core.Services
{
    public class AuctionItemService : IAuctionItem
    {
        private readonly AuctionChatAppDbContext _context;

        public AuctionItemService(AuctionChatAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuctionItem>> GetItemAsync()
        {
            return await _context.AuctionItems.Where(t => t.IsDeleted == false).ToListAsync();
        }

        public async Task<AuctionItem> GetItemByIdAsync(int id)
        {
            return await _context.AuctionItems.FindAsync(id);
        }

        public async Task<AuctionItem> CreateItemAsync(AuctionItem auctionItem)
        {
            // Generate a unique identifier
            auctionItem.ItemUniqueNumber = Guid.NewGuid().ToString().Substring(0, 8);

            auctionItem.Quantity = auctionItem.Quantity != 0 ? auctionItem.Quantity : 1;

            _context.AuctionItems.Add(auctionItem);
            await _context.SaveChangesAsync();
            return auctionItem;
        }

        public async Task UpdateItemAsync(AuctionItem auctionItem)
        {
            _context.Entry(auctionItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var auctionItem = await _context.AuctionItems.FindAsync(id);
            if (auctionItem != null)
            {
                // Set IsDeleted to true
                auctionItem.IsDeleted = true;

                // Update the AuctionItem in the context
                _context.AuctionItems.Update(auctionItem);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
        }
    }
}
