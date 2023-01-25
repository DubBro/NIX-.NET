using Newtonsoft.Json;

namespace Module5HW1.DTOs.Responses
{
    public class LoginResponse
    {
        [JsonProperty(PropertyName = "token")]
        public string? Token { get; set; }
    }
}
