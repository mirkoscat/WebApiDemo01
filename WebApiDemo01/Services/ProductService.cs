using Azure.Core;
using Microsoft.EntityFrameworkCore;
using WebApiDemo01.Data;
using WebApiDemo01.Models;

namespace WebApiDemo01.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }
     
        public async Task<List<Product>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<List<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) 
                return null;
                            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return null;
            return product;
        }

        public async Task<List<Product>> UpdateProduct(int id,Product request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return null;

            product.ProductName = request.ProductName;
            product.ProductCategory = request.ProductCategory;
            product.ProductDescription = request.ProductDescription;
            product.ProductPrice = request.ProductPrice;
            product.ProductStock = request.ProductStock;
            await _context.SaveChangesAsync();

            var products = await _context.Products.ToListAsync();
            return products;
        }
    }
}
