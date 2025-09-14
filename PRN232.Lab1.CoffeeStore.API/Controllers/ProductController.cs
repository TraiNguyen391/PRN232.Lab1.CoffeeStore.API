using Microsoft.AspNetCore.Mvc;
using PRN232.Lab1.CoffeeStore.Service;
using PRN232.Lab1.CoffeeStore.Service.Model.RequestModel;

namespace PRN232.Lab1.CoffeeStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllProducts()
        {
            var product = await _productService.GetAllAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _productService.GetByIdAsync(id);
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

            var createdProduct = await _productService.CreateAsync(product);

            return CreatedAtAction(nameof(GetProductById), new { id = createdProduct }, createdProduct);
        }
    }
}
