using Newtonsoft.Json;

namespace Module5HW1.DTOs.Requests
{
    public class AuthRequest
    {
        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string? Password { get; set; }
    }
}
