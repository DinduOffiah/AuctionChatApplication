using AuctionChatApp.Core.DTOs;
using AuctionChatApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuctionChatApp.API.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthentication _accountService;

        public AuthController(IAuthentication accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _accountService.RegisterUser(model);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _accountService.LoginUser(model);

            if (result.Succeeded)
            {
                var appUser = await _accountService.GetUserByUsername(model.Username);
                return Ok(_accountService.GenerateJwtToken(appUser));
            }

            return Unauthorized();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("assign-admin/{userId}")]
        public async Task<IActionResult> AssignAdmin(string userId)
        {
            var result = await _accountService.AssignAdmin(userId);

            if (result.Succeeded)
            {
                return Ok("User assigned to Admin role");
            }

            return BadRequest("Failed to assign Admin role");
        }
    }
}
