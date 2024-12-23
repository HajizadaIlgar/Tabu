using Tabu.Enums;
using Tabu.ExternalServices.Abstracts;
using Tabu.ExternalServices.Implements;
using Tabu.Services.Abstracts;
using Tabu.Services.Implements;

namespace Tabu
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IWordService, WordService>();
            return services;
        }
        public static IServiceCollection AddCacheService(this IServiceCollection services, IConfiguration _configuration, CacheTypes type = CacheTypes.Redis)
        {
            if (type == CacheTypes.Redis)
            {
                services.AddStackExchangeRedisCache(opt =>
                {
                    opt.Configuration = _configuration.GetConnectionString("Redis");
                    opt.InstanceName = "TabuGame_";
                });
                services.AddScoped<ICacheService, RedisService>();
            }
            else
            {
                services.AddMemoryCache();
                services.AddScoped<ICacheService, LocalCacheService>();
            }
            return services;
        }
    }
}
