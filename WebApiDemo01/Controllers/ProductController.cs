using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo01.Models;

namespace WebApiDemo01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product> {
            new Product{ Id=1, ProductName="product 1", ProductCategory = (Enums.ProductCategory)1,ProductDescription="Description 1" ,ProductPrice=20.00m,ProductStock=300},
            new Product{ Id=2, ProductName="product 2", ProductCategory = (Enums.ProductCategory)2,ProductDescription="Description 2" ,ProductPrice=12.99m,ProductStock=200},
            new Product{ Id = 3, ProductName = "product 3", ProductCategory = (Enums.ProductCategory)3, ProductDescription = "Description 3", ProductPrice = 9.5m, ProductStock = 150 },
            new Product{ Id = 4, ProductName = "product 4", ProductCategory = (Enums.ProductCategory)1, ProductDescription = "Description 4", ProductPrice = 5.99m, ProductStock = 200 }

            };
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {

            return Ok(products);

        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            return Ok(product);

        }
    }
}
