using MicroservicesFramework.Common;
using MicroservicesFramework.Logging.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;

namespace MicroservicesFramework.Logging;

public static class LoggingExtensions
{
    public static IServiceCollection AddLogger(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<LoggerOptions>(configuration.GetSection("Logger"));
        return services.AddLogging();
    }

    public static WebApplicationBuilder UseLogger(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        var options = services.GetOptions<LoggerOptions>();
        var appOptions = services.GetOptions<AppOptions>();

         builder.Host.UseSerilog((context, config) => LoggerConfigurator.ConfigureLogger(context, config, options, appOptions));

        return builder;
    }
}
