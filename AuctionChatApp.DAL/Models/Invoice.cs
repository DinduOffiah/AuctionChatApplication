using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.DAL.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string? RefNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        // Foreign key for User
        public int UserId { get; set; }
        // Navigation property for User
        public User? User { get; set; }

        // Foreign key for AuctionItem
        public int ItemId { get; set; }
        // Navigation property for AuctionItem
        public AuctionItem? Item { get; set; }
    }
}
