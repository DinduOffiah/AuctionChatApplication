using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.DAL.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string? RefNumber { get; set; }
        public string? ItemUniqueNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
