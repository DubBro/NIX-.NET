using System.Text;
using Module5HW1.DTOs.Responses;
using Module5HW1.Services.Abstractions;
using Newtonsoft.Json;

namespace Module5HW1.Services.Instances
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest content = null!)
            where TRequest : class
        {
            var client = _clientFactory.CreateClient();

            var request = new HttpRequestMessage(method, url);

            if (content != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            }

            var result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                if (response is ErrorResponse error && !string.IsNullOrEmpty(error.Error))
                {
                    throw new Exception(error.Error);
                }

                return response!;
            }

            return default!;
        }
    }
}
