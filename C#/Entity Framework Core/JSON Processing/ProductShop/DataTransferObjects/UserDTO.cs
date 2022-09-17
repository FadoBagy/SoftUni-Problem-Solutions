namespace ProductShop.DataTransferObjects
{
    using Newtonsoft.Json;

    [JsonObject]
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }
    }
}
