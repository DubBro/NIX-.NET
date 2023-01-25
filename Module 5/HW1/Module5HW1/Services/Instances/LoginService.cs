using Microsoft.Extensions.Options;
using Module5HW1.Config;
using Module5HW1.DTOs.Requests;
using Module5HW1.DTOs.Responses;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services.Instances
{
    public class LoginService : ILoginService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiOption _options;

        public LoginService(IHttpClientService httpClientService, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        public async Task<LoginResponse> Login(string email, string password)
        {
            var result = await _httpClientService.SendAsync<LoginResponse, AuthRequest>(
                $"{_options.LoginHost}",
                HttpMethod.Post,
                new AuthRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result == null)
            {
                throw new Exception("Unsuccessful log in");
            }

            return result;
        }
    }
}
