using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.DAL.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Foreign key for User
        public int UserId { get; set; }
        // Navigation property for User
        public User? User { get; set; }

        // Foreign key for AuctionItem
        public string? ItemId { get; set; }
        // Navigation property for AuctionItem
        public AuctionItem? Item { get; set; }
    }
}
