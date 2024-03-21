using AuctionChatApp.Core.DTOs;
using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentService _service;

        /// <summary>
        /// Initializes a new instance of the AuctionItemsController class.
        /// </summary>
        /// <param name="service">The service used to manage auction items.</param>
        /// <param name="logger">This is for logging.</param>
        public PaymentsController(IPaymentService service, ILogger<PaymentsController> logger)
        {
            _service = service;
            _logger = logger;
        }



        /// <summary>
        /// This endpoint CREATES auction items.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<PaymentDto>> Pay(PaymentDto itemDto)
        {
            try
            {
                return StatusCode(201, "Payment Successful");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the auction item.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
