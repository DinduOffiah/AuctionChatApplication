using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.DTOs
{
    public class BidDto
    {
        public string? ItemUniqueNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
