using Basket.Host.Models.Requests;
using Basket.Host.Models.Responses;
using Basket.Host.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Basket.Host.Services
{
    public class BasketService : IBasketService
    {
        private readonly ILogger<BasketService> _logger;
        private readonly IInternalHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public BasketService(ILogger<BasketService> logger, IInternalHttpClientService httpClient, IOptions<AppSettings> settings)
        {
            _logger = logger;
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<AddItemResponse<int?>> AddItemToCatalogAsync(CreateProductRequest request)
        {
            var result = await _httpClient.SendAsync<AddItemResponse<int?>, CreateProductRequest>($"{_settings.Value.CatalogApi}/add", HttpMethod.Post, request);
            return result;
        }
    }
}
