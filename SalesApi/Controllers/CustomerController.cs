using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Models;
using SalesApi.Services;
using SalesApi.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try {
                var response = await _customerService.ListCustomer();
                return Ok(response);
            }catch(Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            try
            {
                var id= await _customerService.CreateCustomer(customer);
                return Ok(ResponseUtils.BuildSuccessfullResponse(id));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Customer customer)
        {
            try
            {
                var id = await _customerService.UpdateCustomer(customer);
                return Ok(ResponseUtils.BuildSuccessfullResponse(id));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int customerId)
        {
            try
            {
                var id = await _customerService.DeleteCustomer(customerId);
                return Ok(ResponseUtils.BuildSuccessfullResponse(id));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }
    }
}
