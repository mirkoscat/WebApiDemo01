using System.Text.Json.Serialization;

namespace WebApiDemo01.Models
{
    public class Enums
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum ProductCategory : int { 
        
        Category1=1,
        Category2,
        Category3

        }
    }
}
