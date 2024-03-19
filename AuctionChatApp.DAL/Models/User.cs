using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; } = false;
    }
}
