using Infrastructure.RateLimit.Extensions.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure.RateLimit.Extensions
{
    public static class LimitRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseLimitRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LimitRequestMiddleware>();
        }
    }
}
