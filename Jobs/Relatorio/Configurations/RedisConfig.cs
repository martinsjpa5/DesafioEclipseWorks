using Domain.Models;

namespace Relatorio.Configurations
{
    public static class RedisConfig
    {
        public static IServiceCollection AddRedisConfig(this IServiceCollection services, HostApplicationBuilder builder)
        {
            var redisConnectionSection = builder.Configuration.GetSection("RedisConnection");
            services.Configure<RedisConnectionSettings>(redisConnectionSection);

            var redisConnection = redisConnectionSection.Get<RedisConnectionSettings>();

            builder.Services.AddStackExchangeRedisCache(o =>
            {
                o.InstanceName = redisConnection.InstanceName;
                o.Configuration = redisConnection.Configuration;
            });

            return services;
        }
    }
}
