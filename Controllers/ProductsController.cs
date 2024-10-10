using dan_storbaek_server.Domains;
using dan_storbaek_server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dan_storbaek_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("[action]/{id:length(24)}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _productService.GetProductById(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct(Product newProduct)
        {
            await _productService.CreateAsync(newProduct);

            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("[action]/{id:length(24)}")]
        public async Task<IActionResult> UpdateProduct(string id, Product updatedProduct)
        {
            var product = await _productService.GetProductById(id);

            if (product is null)
            {
                return NotFound();
            }

            updatedProduct.Id = product.Id;

            var latestProduct = await _productService.UpdateAsync(id, updatedProduct);

            return Ok(latestProduct);
        }

        [HttpDelete("[action]/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productService.GetProductById(id);

            if (product is null)
            {
                return NotFound();
            }

            await _productService.RemoveAsync(id);

            return NoContent();
        }

    }
}
