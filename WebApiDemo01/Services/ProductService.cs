using WebApiDemo01.Models;

namespace WebApiDemo01.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product> {
            new Product{ Id=1, ProductName="product 1", ProductCategory = (Enums.ProductCategory)1,ProductDescription="Description 1" ,ProductPrice=20.00m,ProductStock=300},
            new Product{ Id=2, ProductName="product 2", ProductCategory = (Enums.ProductCategory)2,ProductDescription="Description 2" ,ProductPrice=12.99m,ProductStock=200},
            new Product{ Id = 3, ProductName = "product 3", ProductCategory = (Enums.ProductCategory)3, ProductDescription = "Description 3", ProductPrice = 9.5m, ProductStock = 150 },
            new Product{ Id = 4, ProductName = "product 4", ProductCategory = (Enums.ProductCategory)1, ProductDescription = "Description 4", ProductPrice = 5.99m, ProductStock = 200 }

            };
        public List<Product> AddProduct(Product product)
        {
            products.Add(product);
            return products;

        }

        public List<Product> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            products.Remove(product);
            return products;

        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return null;
            return product;
        }

        public List<Product> UpdateProduct(Product request)
        {
            var product = products.Find(x => x.Id == request.Id);
            if (product == null)
                return null;

            product.ProductName = request.ProductName;
            product.ProductCategory = request.ProductCategory;
            product.ProductDescription = request.ProductDescription;
            product.ProductPrice = request.ProductPrice;
            product.ProductStock = request.ProductStock;

            return products;
        }
    }
}
