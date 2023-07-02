using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo01.Models;
using WebApiDemo01.Services;

namespace WebApiDemo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products=await _productService.GetAllProducts();
            if (products == null)
            {
                return NotFound("Product not found");
            }
            return Ok(products);

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if(product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var result= await _productService.AddProduct(product);
            if(result==null)
            {
                return NotFound("Product not found");
            }
            return Ok(result);

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<List<Product>>> UpdateProduct(int id,Product request)
        {
            
            var result = await _productService.UpdateProduct(id, request);
            if (result == null)
                return NotFound("Product not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result= await _productService.DeleteProduct(id);
            if (result == null)
                return NotFound("Product not found");
            return Ok(result);

        }

    }
}
