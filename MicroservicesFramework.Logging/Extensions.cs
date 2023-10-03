using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace MicroservicesFramework.Logging;

public static class Extensions
{
    public static void UseLogger(this WebApplicationBuilder builder)
    {
        builder.Services.AddLogging();
        builder.Host.UseSerilog(LoggerConfigurator.ConfigureLogger);
    }
}
