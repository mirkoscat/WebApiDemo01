using Newtonsoft.Json;
using static WebApiDemo01.Models.Enums;

namespace WebLayer.Models
{
	public class CreateProductViewModel
	{
        public int Id { get; set; }
        public string  ProductName { get; set; }
        public string  ProductDescription { get; set; }
        public decimal  ProductPrice { get; set; }
		public ProductCategory ProductCategory { get; set; }
		public int ProductStock { get; set; } = 0;
	}
}
