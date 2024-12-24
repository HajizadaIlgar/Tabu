using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using Tabu.ExternalServices.Abstracts;

namespace Tabu.ExternalServices.Implements
{
    public class RedisService(IDistributedCache _redis) : ICacheService
    {
        public async Task<T?> GetAsync<T>(string key)
        {
            string? data = await _redis.GetStringAsync(key);
            if (data == null) return default(T);
            return JsonSerializer.Deserialize<T>(data);
        }

        public Task<T?> Remove<T>(string key)
        {
            throw new NotImplementedException();
        }

        public async Task SetAsync<T>(string key, T value, int second = 300)
        {

            string json = JsonSerializer.Serialize(value);
            DistributedCacheEntryOptions opt = new DistributedCacheEntryOptions();
            opt.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(second);
            await _redis.SetStringAsync(key, json, opt);
        }
    }
}
