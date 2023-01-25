using Newtonsoft.Json;

namespace Module5HW1.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string? FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
    }
}
