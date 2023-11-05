using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using MassTransit.Logging;
using MicroservicesFramework.Tracing.Jaeger.Masstransit.Options;
using MicroservicesFramework.Common;
using MicroservicesFramework.Logging.Options;

namespace MicroservicesFramework.Tracing.Jaeger.Masstransit;

public static class MasstransitJeagerExtensions
{
    public static IServiceCollection AddMasstransitToJaegar(this IServiceCollection services)
    {
        var options = services.GetOptions<TracingOptions>("tracing");

        if (ShouldSkipConfiguration(options))
        {
            return services;
        }

        var app = services.GetOptions<AppOptions>("app");
        var masstransitJaeger = options.Jaeger.Masstransit;

        var configureResource = MasstransitJeagerConfigurator.ConfigureResource(app);
        var endpoint = MasstransitJeagerConfigurator.MapEndpoint(masstransitJaeger.Endpoint);
        var protocol = MasstransitJeagerConfigurator.MapProtocol(masstransitJaeger.Protocol);

        services.AddOpenTelemetry()
            .ConfigureResource(configureResource)
            .WithTracing(b => b
                .AddSource(DiagnosticHeaders.DefaultListenerName) 
                .AddOtlpExporter(options =>
                {
                    options.Protocol = protocol;
                    options.Endpoint = endpoint;
                })
            );

        return services;
    }

    private static bool ShouldSkipConfiguration(TracingOptions options)
    {
        return options is null
            || !options.Enabled
            || options.Jaeger is null
            || !options.Jaeger.Enabled
            || options.Jaeger.Masstransit is null
            || !options.Jaeger.Masstransit.Enabled;
    }
}