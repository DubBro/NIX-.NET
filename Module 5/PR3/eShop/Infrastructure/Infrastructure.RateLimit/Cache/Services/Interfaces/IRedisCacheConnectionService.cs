using StackExchange.Redis;

namespace Infrastructure.RateLimit.Cache.Services.Interfaces
{
    public interface IRedisCacheConnectionService
    {
        public IConnectionMultiplexer Connection { get; }
    }
}
