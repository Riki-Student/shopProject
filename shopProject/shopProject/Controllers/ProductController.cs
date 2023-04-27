using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> products = await _productService.GetProducts();
            return products == null ? NoContent() : Ok(products);

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await _productService.GetProductById(id);
            return product == null ? NoContent() : Ok(product);
        }

        //[HttpGet("search/{productName}")]
        //    public async Task<ActionResult<List<Product>>> Get(string productName)
        //{
        //    List<Product> products = await _productService.GetProductByName(productName);
        //    return products == null ? NoContent() : Ok(products);
        //}

        [HttpGet("search")]
        public async Task<IEnumerable<Product>> GetbyPrice([FromQuery] string? desc, [FromQuery]  int? minPrice=null, [FromQuery] int ?maxPrice = null)
        {
            return await _productService.GetProductBySearch(desc, minPrice, maxPrice);
        }


        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product newProduct)
        {
            Product product = await _productService.CreateProduct(newProduct);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
