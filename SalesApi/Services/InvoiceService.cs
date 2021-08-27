using SalesApi.Entities;
using SalesApi.Models;
using SalesApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public class InvoiceService : IInvoiceService
    {
        DbRepositorycs _repository;
        public InvoiceService(DbRepositorycs context)
        {
            _repository = context;
        }
        public async Task<int> createInvoice(InvoiceDto invoice)
        {
            int invoiceId = await _repository.CreateSalesHeader(invoice);
            await _repository.CreateSalesDetails(invoice.details,invoiceId);
            return invoiceId;
        }

        public async Task<List<SalesDetailDto>> getInvoiceDetails(int invoiceId)
        {
            return await _repository.GetDetails(invoiceId);
        }

        public async Task<List<InvoiceDto>> getInvoices()
        {
            return await _repository.GetInvoices();
        }
    }
}
