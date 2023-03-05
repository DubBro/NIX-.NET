using Infrastructure.RateLimit.Cache.Services.Interfaces;
using Infrastructure.RateLimit.Configuration;
using Infrastructure.Services.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.RateLimit.Cache.Services
{
    public class CacheService : ICacheService
    {
        private readonly IRedisCacheConnectionService _redisCacheConnectionService;
        private readonly ILogger<CacheService> _logger;
        private readonly RedisConfig _config;
        private readonly IJsonSerializer _jsonSerializer;

        public CacheService(
            ILogger<CacheService> logger,
            IRedisCacheConnectionService redisCacheConnectionService,
            IOptions<RedisConfig> config,
            IJsonSerializer jsonSerializer)
        {
            _logger = logger;
            _redisCacheConnectionService = redisCacheConnectionService;
            _config = config.Value;
            _jsonSerializer = jsonSerializer;
        }

        public Task AddOrUpdateAsync<T>(string key, T value, TimeSpan? expiry = null, bool keepTtl = false)
            => AddOrUpdateIternalAsync<T>(key, value, expiry, keepTtl);

        public async Task<T> GetAsync<T>(string key)
        {
            var redis = GetRedisDatabase();

            var serialized = await redis.StringGetAsync(key);

            return serialized.HasValue ?
                _jsonSerializer.Deserialize<T>(serialized.ToString())
                : default(T) !;
        }

        private async Task AddOrUpdateIternalAsync<T>(string key, T value, TimeSpan? expiry = null, bool keepTtl = false)
        {
            var redis = GetRedisDatabase();
            expiry = expiry ?? _config.CacheTimeout;
            var serialized = _jsonSerializer.Serialize(value);

            if (await redis.StringSetAsync(key, serialized, expiry, keepTtl))
            {
                _logger.LogInformation($"Cached value for key {key} cached");
            }
            else
            {
                _logger.LogInformation($"Cached value for key {key} updated");
            }
        }

        private IDatabase GetRedisDatabase() => _redisCacheConnectionService.Connection.GetDatabase();
    }
}
