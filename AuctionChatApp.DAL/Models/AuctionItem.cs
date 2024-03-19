using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.DAL.Models
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public string? ItemUniqueNumber { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; } = false;
    }
}
