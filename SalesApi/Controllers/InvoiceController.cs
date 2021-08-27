using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Entities;
using SalesApi.Models;
using SalesApi.Services;

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost]
        public async Task<int> Post([FromBody]InvoiceDto invoice)
        {
            return await _invoiceService.createInvoice(invoice);
        }
        [HttpGet]
        public async Task<List<InvoiceDto>> Get()
        {
            return await _invoiceService.getInvoices();
        }
        [HttpGet("details")]
        public async Task<List<SalesDetailDto>> Get([FromQuery]int invoiceId)
        {
            return await _invoiceService.getInvoiceDetails(invoiceId);
        }
    }
}