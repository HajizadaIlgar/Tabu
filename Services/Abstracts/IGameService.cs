namespace Tabu.Services.Abstracts
{
    public interface IGameService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value);
    }
}
