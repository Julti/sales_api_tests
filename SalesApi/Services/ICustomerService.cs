using SalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> ListCustomer();
        Task<int> CreateCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int customerId);
    }
}
