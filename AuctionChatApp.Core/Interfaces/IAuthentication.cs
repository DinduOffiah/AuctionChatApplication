using AuctionChatApp.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Interfaces
{
    public interface IAuthentication
    {
        Task<IdentityResult> RegisterUser(RegisterModel model);
        Task<SignInResult> LoginUser(LoginModel model);
        Task<IdentityResult> AssignAdmin(string userId);
        string GenerateJwtToken(User user);
    }
}
