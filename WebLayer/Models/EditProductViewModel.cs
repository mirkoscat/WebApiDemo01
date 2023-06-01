using WebApiDemo01.Models;
using static WebApiDemo01.Models.Enums;

namespace WebLayer.Models
{
	public class EditProductViewModel
	{
        //public Product Product { get; set; }= new Product() { ProductName ="Name1"};
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductStock { get; set; } = 0;
    }
}
