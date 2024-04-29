using AuctionChatApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionChatApp.DAL.Data
{
    public class AuctionChatAppDbContext : IdentityDbContext<User>
    {
        public AuctionChatAppDbContext(DbContextOptions<AuctionChatAppDbContext> options)
          : base(options)
        {
        }

        public DbSet<AuctionItem> AuctionItems { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<AuctionItem> Invoices { get; set; }
        public DbSet<User> Users { get; set; }

        //For correctly mapping "Decimal" data type to the corresponding column in the database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>().Property(b => b.Amount).HasPrecision(10, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
