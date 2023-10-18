using MicroservicesFramework.Logging;
using MicroservicesFramework.Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MicroservicesFramework.Trancing.Jaeger;
using MicroservicesFramework.Tracing.Jaeger.Masstransit;
using MicroservicesFramework.Auth;
using MicroservicesFramework.Mediator;

namespace MicroservicesFramework;

public static class Extensions
{
    public static void AddMicroservicesFramework(IServiceCollection services, params Type[] servicesForMediator)
    {
        services.AddJeager()
            .AddMasstransitToJaegar()
            .AddAuth()
            .AddLogger()
            .AddMediator(servicesForMediator);
    }

    public static void UseMicroservicesFramework(WebApplicationBuilder builder)
    {
        builder.UseMetrics()
            .UseLogger();
    }
}
