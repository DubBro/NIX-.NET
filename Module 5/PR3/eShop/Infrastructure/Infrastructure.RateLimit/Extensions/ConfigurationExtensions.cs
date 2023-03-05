using Infrastructure.RateLimit.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.RateLimit.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void AddCacheConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<RedisConfig>(builder.Configuration.GetSection("Redis"));
        }
    }
}
