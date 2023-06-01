using Newtonsoft.Json;
using static WebApiDemo01.Models.Enums;

namespace WebApiDemo01.Models
{
    public class Product
    {
        public int Id { get; set; }
        [JsonProperty("ProductName")]
        public required string ProductName { get; set; }
        [JsonProperty("ProductDescription")]
        public string ProductDescription { get; set; } = String.Empty;
        [JsonProperty("ProductCategory")]
        public ProductCategory ProductCategory { get; set; }
        [JsonProperty("ProductPrice")]
        public decimal ProductPrice { get; set; } = 0;
        [JsonProperty("ProductStock")]
        public int ProductStock { get; set; } = 0;
    }
}
