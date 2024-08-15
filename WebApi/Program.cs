using Domain.Models;
using Ioc.DependenciesInjection;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

var basePath = AppContext.BaseDirectory;

builder.Configuration
    .SetBasePath(basePath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<RabbitMqAppSettings>(builder.Configuration.GetSection("RabbitMq"));

builder.Services.ResolveDependenciesWebApi(builder.Configuration);
builder.Services.AddApiConfig(builder.Configuration);
builder.Services.AddSwaggerConfig();

var app = builder.Build();

app.UseApiConfig(app.Environment);
app.UseSwaggerConfig(app);

app.Run();