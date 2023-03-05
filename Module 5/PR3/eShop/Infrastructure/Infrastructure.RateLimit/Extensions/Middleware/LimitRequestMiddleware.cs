using Infrastructure.RateLimit.Cache.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.RateLimit.Extensions.Middleware
{
    public class LimitRequestMiddleware
    {
        private readonly ICacheService _cacheService;
        private readonly RequestDelegate _next;

        public LimitRequestMiddleware(RequestDelegate next, ICacheService cacheService)
        {
            _next = next;
            _cacheService = cacheService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestIp = context.Connection.RemoteIpAddress;
            var requestPort = context.Connection.RemotePort;
            var requestUrl = context.Request.Path;

            string key = $"{requestUrl}-{requestIp}:{requestPort}";

            var result = await _cacheService.GetAsync<int>(key);

            if (result == default)
            {
                await _cacheService.AddOrUpdateAsync(key, 1);
                await _next(context);
            }

            if (result == 10)
            {
                context.Response.StatusCode = 429;
                return;
            }

            await _cacheService.AddOrUpdateAsync(key, ++result, null, true);
            await _next(context);
        }
    }
}
