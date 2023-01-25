using Newtonsoft.Json;

namespace Module5HW1.DTOs.Responses
{
    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "error")]
        public string? Error { get; set; }
    }
}
