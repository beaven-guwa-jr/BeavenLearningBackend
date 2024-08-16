﻿using BeavenLearningBackend.Models;
using BeavenLearningBackend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BeavenLearningBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService service) : ControllerBase
    {
        List<Product> products = new List<Product>();


        [HttpGet("{id}")]
        public async Task<IActionResult>GetProduct([FromRoute]int id)
        {
            var result = service.FindProduct(id);
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetProductList()
        {
            var result = service.ListProducts();
            return Ok(new { result });
        }



        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductDTO product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            var result = service.AddProduct(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = service.UpdateProduct(product);
            if (result == null) {
                return NotFound();
            }
           return Ok(result);
        }



      
    }
}
