using Microsoft.AspNetCore.Builder;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using MicroservicesFramework.Metrics.Options;

namespace MicroservicesFramework.Logging;

public static class MetricsExtensions
{
    public static WebApplicationBuilder UseMetrics(this WebApplicationBuilder builder, MetricOption metricOptions)
    {
        if (metricOptions is not null && metricOptions.Enabled)
        {
            builder.Host.UseMetrics( options =>
            {
                if (metricOptions.EnablePrometheus)
                {
                    options.EndpointOptions = endpointsOptions =>
                    {
                        endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                        endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                    };
                }
            });
        }

        return builder;
    }
}
