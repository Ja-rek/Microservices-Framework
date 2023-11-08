using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;
using MassTransit.Logging;
using MicroservicesFramework.Tracing.Jaeger.Masstransit.Options;
using MicroservicesFramework.Common;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace MicroservicesFramework.Tracing.Jaeger.Masstransit;

public static class MasstransitJeagerExtensions
{
    public static IServiceCollection AddMasstransitToJaegar(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<MasstransitTracingOptions>(configuration.GetSection("Tracing"));

        var options = services.GetOptions<MasstransitTracingOptions>();

        if (ShouldSkipConfiguration(options))
        {
            return services;
        }

        var app = services.BuildServiceProvider()
            .GetRequiredService<IOptions<AppOptions>>()
            ?.Value;
        var masstransitJaeger = options?.Jaeger?.Masstransit;

        var configureResource = MasstransitJeagerConfigurator.ConfigureResource(app);
        var endpoint = MasstransitJeagerConfigurator.MapEndpoint(masstransitJaeger?.Endpoint);
        var protocol = MasstransitJeagerConfigurator.MapProtocol(masstransitJaeger?.Protocol);

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

    private static bool ShouldSkipConfiguration(MasstransitTracingOptions? options)
    {
        return options is null
            || !options.Enabled
            || options.Jaeger is null
            || !options.Jaeger.Enabled
            || options.Jaeger.Masstransit is null
            || !options.Jaeger.Masstransit.Enabled;
    }
}