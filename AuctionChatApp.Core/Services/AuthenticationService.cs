using AuctionChatApp.Core.DTOs;
using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _config;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
        }

        public Task<IdentityResult> AssignAdmin(string userId)
        {
            throw new NotImplementedException();
        }

        public string GenerateJwtToken(User user)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> LoginUser(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel model)
        {
            var user = new User { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result;
        }
    }
}
