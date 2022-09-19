﻿namespace CarDealer.DTO
{
    using Newtonsoft.Json;

    [JsonObject]
    public class SaleDto
    {
        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public decimal Discount { get; set; }
    }
}
