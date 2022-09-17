namespace ProductShop.DataTransferObjects
{
    using Newtonsoft.Json;

    [JsonObject]
    public class CategoryProductDto
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}
