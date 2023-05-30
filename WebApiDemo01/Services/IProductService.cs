using Microsoft.AspNetCore.Mvc;
using WebApiDemo01.Models;

namespace WebApiDemo01.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        List<Product> AddProduct(Product product);
        List<Product> UpdateProduct(Product request);
        List<Product> DeleteProduct(int id);
    }
}
