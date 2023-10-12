using MicroservicesFramework.Logging;
using MicroservicesFramework.Mediator;
using MicroservicesFramework.Metrics.Options;
using MicroservicesFramework.Metrics;
using Microsoft.AspNetCore.Builder;
using MicroservicesFramework.Logging.Options;

namespace MicroservicesFramework;

public static class Extensions
{
    public static void UseMicroservicesFramework(WebApplicationBuilder builder, WebApplication app, params Type[] servicesForMediator)
    {
        var metricOptions = app.Configuration.GetOptions<MetricOption>("metrics");
        var loggerOption = app.Configuration.GetOptions<LoggerOption>("logger");

        builder.UseLogger(loggerOption);
        builder.UseMediator(servicesForMediator);
        builder.UseMetrics(metricOptions);
    }
}
