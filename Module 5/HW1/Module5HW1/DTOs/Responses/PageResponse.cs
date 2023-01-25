using Newtonsoft.Json;

namespace Module5HW1.DTOs.Responses
{
    public class PageResponse<T>
        where T : class
    {
        public int Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
        public IList<T>? Data { get; set; }
        public SupportDTO? Support { get; set; }
    }
}
