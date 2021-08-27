using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Models;
using SalesApi.Services;

namespace SalesApi.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<List<Product>> List()
        {
            return await _productService.ListProducts();
        }
        [HttpPost]
        public async Task<int> CreateProduct([FromBody]Product product)
        {
            return await _productService.CreateProduct(product);
        }
        [HttpPut]
        public async Task<int> UpdateProduct([FromBody]Product product)
        {
            return await _productService.UpdateProduct(product);
        }
        [HttpDelete]
        public async Task<int> DeleteProduct([FromQuery]int productId)
        {
            return await _productService.DeleteProduct(productId);
        }


    }
}