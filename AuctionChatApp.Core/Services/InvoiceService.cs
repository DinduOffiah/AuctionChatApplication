using AuctionChatApp.Core.DTOs;
using AuctionChatApp.Core.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Services
{
    internal class InvoiceService : IInvoiceService
    {
        private readonly IRoomService _roomService;

        public async Task<InvoiceDto> GetInvoiceAsync()
        {
            var highestBid = await _roomService.GetHighestBidAsync();

            if (highestBid == null)
            {
                throw new Exception("No bids found.");
            }

            var invoice = new InvoiceDto
            {
                RefNumber = highestBid.ItemUniqueNumber,
                Amount = highestBid.Amount,
                Date = DateTime.Now
            };

            // Publish message to RabbitMQ
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "paymentQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = $"Invoice generated for item {invoice.RefNumber} with amount {invoice.Amount}";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "paymentQueue",
                                     basicProperties: null,
                                     body: body);
            }

            return invoice;
        }
    }
}
