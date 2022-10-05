using DemoRedisCache.Configurations;
using DemoRedisCache.Services;
using StackExchange.Redis;

namespace DemoRedisCache.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void InstallerServices(WebApplicationBuilder builder, IConfiguration configuration)
        {
            var redisConfiguration = new RedisConfiguration();
            configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);

            builder.Services.AddSingleton(redisConfiguration);

            if (!redisConfiguration.Enabled)
                return;

            builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
            builder.Services.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);
            builder.Services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}