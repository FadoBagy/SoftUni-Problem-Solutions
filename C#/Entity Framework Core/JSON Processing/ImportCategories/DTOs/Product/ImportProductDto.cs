using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.DTOs.Product
{
    [JsonObject]
    public class ImportProductDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Required]
        public decimal Price { get; set; }

        [JsonProperty("SellerId")]
        public int SellerId { get; set; }

        [JsonProperty("BuyerId")]
        public int? BuyerId { get; set; }
    }
}
