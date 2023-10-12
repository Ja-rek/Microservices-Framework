using MicroservicesFramework.Logging.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MicroservicesFramework.Logging;

public static class LoggingExtensions
{
    public static WebApplicationBuilder UseLogger(this WebApplicationBuilder builder, LoggerOption options)
    {
        builder.Services.AddLogging();
        builder.Host.UseSerilog((context, config) => LoggerConfigurator.ConfigureLogger(context, config, options));

        return builder;
    }
}
