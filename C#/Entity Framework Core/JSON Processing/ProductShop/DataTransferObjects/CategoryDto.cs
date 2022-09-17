
namespace ProductShop.DataTransferObjects
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CategoryDto
    {
        public string Name { get; set; }
    }
}
