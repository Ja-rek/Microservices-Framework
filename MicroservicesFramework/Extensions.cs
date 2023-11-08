using MicroservicesFramework.Logging;
using MicroservicesFramework.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MicroservicesFramework.Trancing.Jaeger;
using MicroservicesFramework.Tracing.Jaeger.Masstransit;
using MicroservicesFramework.Auth;
using MicroservicesFramework.Mediator;
using Microsoft.Extensions.Configuration;

namespace MicroservicesFramework;

public static class Extensions
{
    public static IServiceCollection AddMicroservicesFramework(this IServiceCollection services, ConfigurationManager configuration, params Type[] servicesForMediator)
    {
        return services.AddJeager(configuration)
            .AddMasstransitToJaegar(configuration)
            .AddAuth(configuration)
            .AddLogger(configuration)
            .AddMediator(servicesForMediator)
            .AddMetrics(configuration);
    }

    public static WebApplicationBuilder UseMicroservicesFramework(this WebApplicationBuilder builder)
    {
        return builder.UseMetrics()
            .UseLogger();
    }
}
