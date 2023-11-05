using Microsoft.AspNetCore.Builder;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using MicroservicesFramework.Metrics.Options;
using MicroservicesFramework.Common;
using App.Metrics.AspNetCore.Endpoints;

namespace MicroservicesFramework.Metrics;

public static class MetricsExtensions
{
        public static WebApplicationBuilder UseMetrics(this WebApplicationBuilder builder)
    {
        var metricOptions = builder.Configuration.GetOptions<MetricOption>("metrics");

        if (metricOptions is not null && metricOptions.Enabled)
        {
            builder.Host.UseMetrics(options =>
            {
                if (metricOptions.EnablePrometheus)
                {
                    options.EndpointOptions = ConfigurePrometheusEndpoint(options.EndpointOptions);
                }
            });
        }

        return builder;
    }

    private static Action<MetricEndpointsOptions> ConfigurePrometheusEndpoint(Action<MetricEndpointsOptions> endpointOptions)
    {
        return endpointsOptions =>
        {
            endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
            endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
        };
    }
}
