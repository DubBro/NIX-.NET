using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.DTOs;
using Module5HW1.DTOs.Responses;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services.Instances
{
    public class ResourceService : IResourceService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiOption _options;

        public ResourceService(IHttpClientService httpClientService, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        public async Task<ResourceDTO> GetResource(int id)
        {
            var result = await _httpClientService.SendAsync<SingleDataResponse<ResourceDTO>, object>($"{_options.ResourceHost}{id}", HttpMethod.Get);

            if (result == null || result.Data == null)
            {
                throw new Exception($"Resource with id = {id} was not found");
            }

            return result.Data;
        }

        public async Task<IList<ResourceDTO>> GetResources(int page)
        {
            var result = await _httpClientService.SendAsync<PageResponse<ResourceDTO>, object>($"{_options.ResourceHost}?page={page}", HttpMethod.Get);

            if (result == null || result.Data == null)
            {
                throw new Exception($"No data was found");
            }

            return result.Data;
        }
    }
}
