using AuctionChatApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionChatApp.Core.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> GetInvoiceAsync();
    }
}
