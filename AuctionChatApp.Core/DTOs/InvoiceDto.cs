using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.DTOs
{
    public class InvoiceDto
    {
        public string? RefNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
