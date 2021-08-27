using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Models;
using SalesApi.Services;

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
        public async Task<List<Customer>> List()
        {
            return await _customerService.ListCustomer();
        }

        [HttpPost]
        public async Task<int> Post([FromBody]Customer customer)
        {
            Console.WriteLine(customer.Name);
            return await _customerService.CreateCustomer(customer);
        }

        [HttpPut]
        public async Task<int> Put([FromBody]Customer customer)
        {
            return await _customerService.UpdateCustomer(customer);
        }

        [HttpDelete]
        public async Task<int> Delete([FromQuery]int customerId)
        {
            return await _customerService.DeleteCustomer(customerId);
        }
    }
}
