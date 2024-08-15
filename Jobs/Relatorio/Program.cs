using Domain.Models;
using Ioc.DependenciesInjection;
using Relatorio;
using Relatorio.Configurations;

var builder = Host.CreateApplicationBuilder(args);


var basePath = AppContext.BaseDirectory;

builder.Configuration
    .SetBasePath(basePath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.Configure<RabbitMqAppSettings>(builder.Configuration.GetSection("RabbitMq"));

builder.Services.AddRedisConfig(builder);

builder.Services.ResolveDependenciesJob(builder.Configuration);

builder.Services.AddHostedService<RelatorioJob>();

var host = builder.Build();
host.Run();
