using SalesApi.Models;
using SalesApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public class CustomerService : ICustomerService
    {
        DbRepositorycs _repository;
        public CustomerService(DbRepositorycs context)
        {
            _repository = context;
        }

        public async Task<int> CreateCustomer(Customer customer)
        {
            return await _repository.CreateCustomer(customer);
        }

        public async Task<int> DeleteCustomer(int customerId)
        {
            return await _repository.DeleteCustomer(customerId);
        }

        public async Task<List<Customer>> ListCustomer()
        {
            return await _repository.GetCustomers();
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            return await _repository.UpdateCustomer(customer);
        }
    }
}
