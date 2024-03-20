using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.DTOs
{
    // DTO for creating an item
    public class CreateAuctionItemDto
    {
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailableForAuction { get; set; }
    }

    // DTO for reading an item
    public class ReadAuctionItemDto
    {
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string? ItemUniqueNumber { get; set; }
        public bool IsAvailableForAuction { get; set; }
    }
}
