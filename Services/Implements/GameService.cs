using Microsoft.Extensions.Caching.Memory;
using Tabu.DAL;
using Tabu.Services.Abstracts;

namespace Tabu.Services.Implements
{
    public class GameService(IMemoryCache _cache, TabuDbContext _context) : IGameService
    {
        public Task GetAllAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
