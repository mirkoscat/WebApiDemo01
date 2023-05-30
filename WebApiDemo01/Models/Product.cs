using static WebApiDemo01.Models.Enums;

namespace WebApiDemo01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public string ProductDescription { get; set; }= String.Empty;
        public ProductCategory ProductCategory { get; set; }
        public decimal ProductPrice { get; set; } = 0;
        public int ProductStock { get; set; } = 0;
    }
}
