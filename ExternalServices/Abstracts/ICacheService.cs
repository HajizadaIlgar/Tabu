namespace Tabu.ExternalServices.Abstracts
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, int second = 300);
        Task<T?> Remove<T>(string key);
    }
}
