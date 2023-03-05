using Infrastructure.RateLimit.Cache.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.RateLimit.Filters
{
    public class LimitRequestFilterAttribute : ActionFilterAttribute
    {
        private readonly ICacheService _cacheService;

        public LimitRequestFilterAttribute(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var requestIp = context.HttpContext.Connection.RemoteIpAddress;
            var requestPort = context.HttpContext.Connection.RemotePort;
            var requestUrl = context.HttpContext.Request.Path;

            string key = $"{requestUrl}-{requestIp}:{requestPort}";

            var result = await _cacheService.GetAsync<int>(key);

            if (result == default)
            {
                await _cacheService.AddOrUpdateAsync(key, 1);
                await next();
                return;
            }

            if (result == 10)
            {
                context.HttpContext.Response.StatusCode = 429;
                return;
            }

            await _cacheService.AddOrUpdateAsync(key, ++result, null, true);
            await next();
        }
    }
}
