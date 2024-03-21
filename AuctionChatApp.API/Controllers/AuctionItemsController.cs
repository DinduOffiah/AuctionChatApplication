using AuctionChatApp.Core.DTOs;
using AuctionChatApp.Core.Interfaces;
using AuctionChatApp.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionItemsController : ControllerBase
    {
        private readonly ILogger<AuctionItemsController> _logger;
        private readonly IAuctionItem _service;

        /// <summary>
        /// Initializes a new instance of the AuctionItemsController class.
        /// </summary>
        /// <param name="service">The service used to manage auction items.</param>
        /// <param name="logger">This is for logging.</param>
        public AuctionItemsController(IAuctionItem service, ILogger<AuctionItemsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// This endpoint gets a LIST of auction items.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var items = await _service.GetItemAsync();

                if (items == null || !items.Any())
                {
                    return NotFound("No auctioned item found.");
                }

                var itemDtos = items.Select(e => new ReadAuctionItemDto
                {
                    ItemUniqueNumber = e.ItemUniqueNumber,
                    ItemName = e.ItemName,
                    Description = e.Description,
                    Quantity = e.Quantity,
                    IsAvailableForAuction = e.IsAvailableForAuction,
                    StopTime = e.StopTime,
                }).ToList();

                return Ok(itemDtos);
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging purposes
                _logger.LogError(ex, "An error occurred while getting auction items.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// This endpoint gets DETAILS of an auction item by Id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadAuctionItemDto>> GetItem(int id)
        {
            try
            {
                var item = await _service.GetItemByIdAsync(id);

                if (item == null)
                {
                    return NotFound($"Auction item with id {id} not found.");
                }

                var itemDto = new ReadAuctionItemDto
                {
                    ItemUniqueNumber = item.ItemUniqueNumber,
                    ItemName = item.ItemName,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    IsAvailableForAuction = item.IsAvailableForAuction,
                    StopTime = item.StopTime,
                };

                return Ok(itemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the auction item with id {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// This endpoint CREATES auction items.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CreateAuctionItemDto>> PostItem(CreateAuctionItemDto itemDto)
        {
            try
            {
                var item = new AuctionItem
                {
                    ItemName = itemDto.ItemName,
                    Description = itemDto.Description,
                    Quantity = itemDto.Quantity,
                    IsAvailableForAuction = itemDto.IsAvailableForAuction,
                    StopTime = itemDto.StopTime,
                };

                var newItem = await _service.CreateItemAsync(item);

                if (newItem == null)
                {
                    return BadRequest("Error creating auction item.");
                }

                var newItemDto = new ReadAuctionItemDto
                {
                    ItemUniqueNumber = newItem.ItemUniqueNumber,
                    ItemName = newItem.ItemName,
                    Description = newItem.Description,
                    Quantity = newItem.Quantity,
                    IsAvailableForAuction = newItem.IsAvailableForAuction,
                    StopTime = newItem.StopTime,
                };

                return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the auction item.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// This endpoint UPDATES/EDITS auction items.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, CreateAuctionItemDto itemDto)
        {
            try
            {
                var item = await _service.GetItemByIdAsync(id);
                if (item == null)
                {
                    return NotFound($"Auction item with id {id} not found.");
                }

                item.ItemName = itemDto.ItemName ?? item.ItemName;
                item.Description = itemDto.Description ?? item.Description;
                item.Quantity = itemDto.Quantity;

                await _service.UpdateItemAsync(item);

                var updatedItemDto = new ReadAuctionItemDto
                {
                    ItemName = item.ItemName,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    ItemUniqueNumber = item.ItemUniqueNumber,
                    StopTime = item.StopTime,
                };

                return Ok(updatedItemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the auction item with id {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        /// <summary>
        /// This endpoint DELETES auction items.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                var itemToDelete = await _service.GetItemByIdAsync(id);
                if (itemToDelete == null)
                {
                    return NotFound($"Auction item with id {id} not found.");
                }

                var itemDto = new ReadAuctionItemDto
                {
                    ItemUniqueNumber = itemToDelete.ItemUniqueNumber,
                    ItemName = itemToDelete.ItemName,
                    Description = itemToDelete.Description,
                    Quantity = itemToDelete.Quantity,
                    StopTime = itemToDelete.StopTime,
                };

                await _service.DeleteItemAsync(id);

                return Ok(itemDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the auction item with id {id}.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
