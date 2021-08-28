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
using SalesApi.Util;

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
        public async Task<IActionResult> Post([FromBody]InvoiceDto invoice)
        {
            try
            {
                var response = await _invoiceService.createInvoice(invoice);
                return Ok(ResponseUtils.BuildSuccessfullResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = _invoiceService.getInvoices();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }
        [HttpGet("details")]
        public async Task<IActionResult> Get([FromQuery]int invoiceId)
        {
            try
            {
                var response = await _invoiceService.getInvoiceDetails(invoiceId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }
    }
}