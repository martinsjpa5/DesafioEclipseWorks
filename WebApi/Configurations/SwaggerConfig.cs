using Microsoft.OpenApi.Models;

namespace WebApi.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new()
                    {
                        Title = "Desafio Eclipse",
                        Version = "v1",
                        Description = "",
                        Contact = new() { Name = "Desafio Eclipse" },
                        License = new() { Name = "MIT", Url = new("https://opensource.org/licenses/MIT") }
                    }
                    );
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, WebApplication webApplication)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
