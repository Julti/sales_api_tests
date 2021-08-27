using SalesApi.Models;
using SalesApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public class ProductService : IProductService
    {
        DbRepositorycs _repository;
        public ProductService(DbRepositorycs context)
        {
            _repository = context;
        }

        public async Task<int> CreateProduct(Product product)
        {
            return await _repository.CreateProduct(product);
        }

        public async Task<int> DeleteProduct(int productId)
        {
            return await _repository.DeleteProduct(productId);
        }

        public async Task<List<Product>> ListProducts()
        {
            return await _repository.Get();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            return await _repository.UpdateProduct(product);
        }
    }
}
