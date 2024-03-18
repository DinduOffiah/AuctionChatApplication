using AuctionChatApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionChatApp.DAL.Data
{
    public class AuctionChatAppDbContext : DbContext
    {
        public AuctionChatAppDbContext(DbContextOptions<AuctionChatAppDbContext> options)
          : base(options)
        {
        }

        public DbSet<AuctionItem> AuctionItems { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<AuctionItem> Invoices { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
