using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiDeneme.BLL;
using MyApiDeneme.Core.Entities;
using System.Security.Cryptography.X509Certificates;

namespace MyApiDeneme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts()
        {
            var products = await _productsService.GetAllProductsAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await _productsService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Products>> PostProduct(Products product)
        {
            await _productsService.AddProductAsync(product);

            return CreatedAtAction(nameof(GetProduct), new {id = product.ProductID}, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Products product)
        {
            if(id != product.ProductID)
                return BadRequest();

            await _productsService.UpdateProductAsync(product);

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productsService.DeleteProductAsync(id);

            return NoContent();
        }
    }
}
