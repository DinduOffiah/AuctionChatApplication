using Microsoft.AspNetCore.Mvc;

namespace AuctionChatApp.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
