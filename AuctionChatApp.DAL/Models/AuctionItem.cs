using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.DAL.Models
{
    public class AuctionItem : BaseEntity
    {
        public int Id { get; set; }
        public string? ItemUniqueNumber { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailableForAuction { get; set; }
        public DateTime? StopTime { get; set; }
    }
}
