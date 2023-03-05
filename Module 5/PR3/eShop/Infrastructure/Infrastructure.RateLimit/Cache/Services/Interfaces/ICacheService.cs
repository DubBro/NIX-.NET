namespace Infrastructure.RateLimit.Cache.Services.Interfaces
{
    public interface ICacheService
    {
        Task AddOrUpdateAsync<T>(string key, T value, TimeSpan? expiry = null, bool keepTtl = false);
        Task<T> GetAsync<T>(string key);
    }
}
