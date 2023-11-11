using MicroFusion.Logging;
using MicroFusion.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MicroFusion.Trancing.Jaeger;
using MicroFusion.Tracing.Jaeger.Masstransit;
using MicroFusion.Auth;
using MicroFusion.Mediator;
using Microsoft.Extensions.Configuration;

namespace MicroFusion;

public static class Extensions
{
    public static IServiceCollection AddMicroFusion(this IServiceCollection services, ConfigurationManager configuration, params Type[] servicesForMediator)
    {
        return services.AddJeager(configuration)
            .AddMasstransitToJaegar(configuration)
            .AddAuth(configuration)
            .AddLogger(configuration)
            .AddMediator(servicesForMediator)
            .AddMetrics(configuration);
    }

    public static WebApplicationBuilder UseMicroFusion(this WebApplicationBuilder builder)
    {
        return builder.UseMetrics()
            .UseLogger();
    }
}

