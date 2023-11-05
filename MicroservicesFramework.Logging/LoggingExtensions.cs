using MicroservicesFramework.Common;
using MicroservicesFramework.Logging.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MicroservicesFramework.Logging;

public static class LoggingExtensions
{
    public static IServiceCollection AddLogger(this IServiceCollection services)
    {
        return services.AddLogger();
    }

    public static WebApplicationBuilder UseLogger(this WebApplicationBuilder builder)
    {
        var options = builder.Configuration.GetOptions<LoggerOptions>("Logger");
        var appOptions = builder.Configuration.GetOptions<AppOptions>("App");

         builder.Host.UseSerilog((context, config) => LoggerConfigurator.ConfigureLogger(context, config, options, appOptions));

        return builder;
    }
}
