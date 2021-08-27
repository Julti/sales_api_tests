using SalesApi.Entities;
using SalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public interface IInvoiceService
    {
        Task<int> createInvoice(InvoiceDto invoice);
        Task<List<InvoiceDto> > getInvoices();
        Task<List<SalesDetailDto>> getInvoiceDetails(int invoiceId);
    }
}
