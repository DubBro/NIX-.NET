using Newtonsoft.Json;

namespace Module5HW1.DTOs.Responses
{
    public class RegisterResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string? Token { get; set; }
    }
}
