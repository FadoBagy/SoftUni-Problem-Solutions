namespace CarDealer.DTO
{
    using Newtonsoft.Json;

    [JsonObject]
    public class SupplierDto
    {
        public string Name { get; set; }

        public bool IsImporter { get; set; }
    }
}
