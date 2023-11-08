using Microsoft.AspNetCore.Builder;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using MicroservicesFramework.Metrics.Options;
using App.Metrics.AspNetCore.Endpoints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MicroservicesFramework.Common;
using Microsoft.Extensions.Configuration;

namespace MicroservicesFramework.Metrics;

public static class MetricsExtensions
{

    public static IServiceCollection AddMetrics(this IServiceCollection services, ConfigurationManager configuration)
    {
        return services.Configure<MetricsOptions>(configuration.GetSection("Metrics"));
    }

    public static WebApplicationBuilder UseMetrics(this WebApplicationBuilder builder)
    {
        var metricOptions = builder.Services.GetOptions<MetricsOptions>();

        if (metricOptions is not null && metricOptions.Enabled)
        {
            builder.Host.UseMetrics(options =>
            {
                if (metricOptions.EnablePrometheus)
                {
                    options.EndpointOptions = ConfigurePrometheusEndpoint();
                }
            });
        }

        return builder;
    }

    private static Action<MetricEndpointsOptions> ConfigurePrometheusEndpoint()
    {
        return endpointsOptions =>
        {
            endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
            endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
        };
    }
}
