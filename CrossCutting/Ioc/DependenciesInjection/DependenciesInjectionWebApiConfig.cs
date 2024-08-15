using Application.Interfaces;
using Application.Services;
using Domain.Interfaces.Caching.Repositories;
using Domain.Interfaces.Queues;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using ExternalServices.Interfaces;
using ExternalServices.Services;
using Infra.Caching.Repositories;
using Infra.Dapper.Repositories;
using Infra.EF.Contexts;
using Infra.EF.Repositories;
using Infra.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ioc.DependenciesInjection
{
    public static class DependenciesInjectionWebApiConfig
    {
        public static IServiceCollection ResolveDependenciesWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            #region EF
            services.AddScoped<DatabaseContext>();
            #endregion

            #region Dapper
            services.AddScoped<ICommonRepositoryDapper>(provider => new CommonRepositoryDapper(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRelatorioRepositoryDapper, RelatorioRepositoryDapper>();
            #endregion

            #region Caching Repository
            services.AddScoped<ICommonCachingRepository, CommonCachingRepository>();
            #endregion

            #region Queues
            services.AddScoped<IRelatorioQueue, RelatorioQueue>();
            #endregion
            #region Repositories
            services.AddScoped<ICommonRepositoryEF, CommonRepositoryEF>();
            #endregion

            #region Application Services
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IComentarioService, ComentarioService>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRelatorioService, RelatorioService>();
            #endregion

            #region Domain Services
            services.AddScoped<ITarefaDomainService, TarefaDomainService>();
            #endregion

            #region External Services
            services.AddSingleton<IAuthExternalService, AuthExternalService>();
            #endregion

            return services;
        }
    }
}
