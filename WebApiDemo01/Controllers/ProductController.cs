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

            return Ok(_productService.GetAllProducts());

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {
           
            return Ok(_productService.GetProduct(id));

        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            
            return Ok(_productService.AddProduct(product));

        }

        [HttpPut]

        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            
            return Ok(_productService.UpdateProduct(request));

        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            
            return Ok(_productService.DeleteProduct(id));

        }

    }
}
