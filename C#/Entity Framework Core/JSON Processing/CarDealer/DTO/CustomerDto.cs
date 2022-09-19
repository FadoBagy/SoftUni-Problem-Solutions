namespace CarDealer.DTO
{
    using Newtonsoft.Json;
    using System;

    [JsonObject]
    public class CustomerDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
