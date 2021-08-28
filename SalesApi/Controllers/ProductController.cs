using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Models;
using SalesApi.Services;
using SalesApi.Util;

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
        public async Task<IActionResult> List()
        {
            try
            {
                var response = await _productService.ListProducts();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]Product product)
        {
            try
            {
                var response = await _productService.CreateProduct(product);
                return Ok(ResponseUtils.BuildSuccessfullResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product)
        {
            try
            {
                var response = await _productService.UpdateProduct(product);
                return Ok(ResponseUtils.BuildSuccessfullResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromQuery]int productId)
        {
            try
            {
                var response = await _productService.DeleteProduct(productId);
                return Ok(ResponseUtils.BuildSuccessfullResponse(response));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseUtils.BuildUnsuccessfullResponse(e));
            }
        }


    }
}