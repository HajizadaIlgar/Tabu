using Microsoft.Extensions.Caching.Memory;
using Tabu.ExternalServices.Abstracts;

namespace Tabu.ExternalServices.Implements;

public class LocalCacheService(IMemoryCache _cache) : ICacheService
{
    public async Task<T?> GetAsync<T>(string key)
    {
        T? value = default(T);
        await Task.Run(() =>
        {
            _cache.TryGetValue(key, out value);
        });
        return value;
    }
    public async Task<T?> Remove<T>(string key)
    {
        T? value = default(T);
        if (_cache.TryGetValue(key, out object? obj))
        {
            value = (T?)obj;
        }
        _cache.Remove(key);
        return value;
    }
    public async Task SetAsync<T>(string key, T value, int second = 300)
    {
        await Task.Run(() =>
        {
            _cache.Set<T>(key, value, DateTime.Now.AddSeconds(second));
        });
    }


}
