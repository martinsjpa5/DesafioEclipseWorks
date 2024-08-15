using Domain.Models;
using Infra.EF.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utils.Response;
using WebApi.Extensions;

namespace WebApi.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddDbContext<DatabaseContext>(options =>
            {
                string defaultConnection = configuration.GetConnectionString("DefaultConnection")!;
                options.UseSqlServer(defaultConnection);

            });

            var redisConnectionSection = configuration.GetSection("RedisConnection");
            services.Configure<RedisConnectionSettings>(redisConnectionSection);

            var redisConnection = redisConnectionSection.Get<RedisConnectionSettings>();
            services.AddStackExchangeRedisCache(o =>
            {
                o.InstanceName = redisConnection.InstanceName;
                o.Configuration = redisConnection.Configuration;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = false;
                options.InvalidModelStateResponseFactory = context =>
                {
                    var erros = context.ModelState.Values.SelectMany(e => e.Errors);
                    var errosResult = erros.Select(x => x.ErrorMessage).ToList();

                    return new UnprocessableEntityObjectResult(CommonResponse.ErroBuilder(errosResult));
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader());


                options.AddPolicy("Production",
                    builder =>
                        builder
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader());
            });

            return services;
        }

        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("Development");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors("Production");
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
