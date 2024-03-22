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
        private readonly ILogger<AuctionItemsController> _logger;
        private readonly IPaymentService _service;
        private readonly IInvoiceService _invoiceService;

        /// <summary>
        /// Initializes a new instance of the AuctionItemsController class.
        /// </summary>
        /// <param name="service">The service used to manage auction items.</param>
        /// <param name="logger">This is for logging.</param>
        public PaymentsController(IPaymentService service, ILogger<AuctionItemsController> logger, IInvoiceService invoice)
        {
            _service = service;
            _invoiceService = invoice;
            _logger = logger;
        }


        /// <summary>
        /// This endpoint generates invoice.
        /// </summary>
        // GET: api/YourController/Invoice
        //[HttpGet("Invoice")]
        //public async Task<ActionResult<InvoiceDto>> GetInvoice()
        //{
        //    try
        //    {
        //        var invoice = await _invoiceService.GetInvoiceAsync();
        //        return Ok(invoice);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception details for debugging purposes
        //        _logger.LogError(ex, "An error occurred while getting the invoice.");
        //        return StatusCode(500, "Internal server error. Please try again later.");
        //    }
        //}


        /// <summary>
        /// This endpoint PAYs for item as highest bidder.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> Pay(InvoiceDto invoiceDTO)
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
