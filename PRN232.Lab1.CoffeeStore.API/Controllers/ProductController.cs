using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Repository.UnitOfWork;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;
using PRN232.Lab1.CoffeeStore.Service.ServiceProviders;

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IServiceProviders _serviceProviders;

        public ProductController(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllProducts()
        {
            var product = await _serviceProviders.ProductService.GetAllAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _serviceProviders.ProductService.GetByIdAsync(id);
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var createdProduct = await _serviceProviders.ProductService.CreateAsync(product);

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct }, createdProduct);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestModel product)
        {
            if (product == null || id == 0)
            {
                return BadRequest();
            }

            var existingProduct = await _serviceProviders.ProductService.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            await _serviceProviders.ProductService.UpdateAsync(id, product);

            var result = await _serviceProviders.ProductService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var existingProduct = await _serviceProviders.ProductService.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return NotFound();
            }

            await _serviceProviders.ProductService.DeleteAsync(id);

            return NoContent();
        }
    }
}
