using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Caching.Repositories;
using Domain.Interfaces.Queues;
using Domain.Interfaces.Repositories;
using Domain.Models;
using ExternalServices.Interfaces;
using ExternalServices.Services;
using Infra.Caching.Repositories;
using Infra.Dapper.Repositories;
using Infra.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc.DependenciesInjection
{
    public static class DependenciesInjectionJobConfig
    {
        public static IServiceCollection ResolveDependenciesJob(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddSingleton<IRelatorioService, RelatorioService>();
            #endregion

            #region Dapper Repositories
            services.AddSingleton<ICommonRepositoryDapper>(provider => new CommonRepositoryDapper(configuration.GetConnectionString("DefaultConnection")!));
            services.AddSingleton<IRelatorioRepositoryDapper, RelatorioRepositoryDapper>();
            #endregion

            #region Cache Repositories
            services.AddSingleton<ICommonCachingRepository, CommonCachingRepository>();
            #endregion

            #region External Services
            services.AddSingleton<IAuthExternalService, AuthExternalService>();
            #endregion

            #region Queues
            services.AddSingleton<IRelatorioQueue, RelatorioQueue>();
            #endregion

            return services;
        }
    }
}