using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.DAL.Models
{
    public class User : IdentityUser
    {
        public string? Username { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; } = false;
    }
}
