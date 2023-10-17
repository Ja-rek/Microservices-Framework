using MicroservicesFramework.Common;
using MicroservicesFramework.Logging.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MicroservicesFramework.Logging;

public static class LoggingExtensions
{
    public static IServiceCollection AddLogging(this IServiceCollection services)
    {
        return services.AddLogging();
    }

    public static WebApplicationBuilder UseLogging(this WebApplicationBuilder builder)
    {
        var options = builder.Configuration.GetOptions<LoggerOptions>("Logger");
         builder.Host.UseSerilog((context, config) => LoggerConfigurator.ConfigureLogger(context, config, options));

        return builder;
    }
}
