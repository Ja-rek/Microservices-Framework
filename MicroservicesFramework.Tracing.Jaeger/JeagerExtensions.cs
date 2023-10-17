using Jaeger;
using Jaeger.Reporters;
using OpenTracing;
using OpenTracing.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MicroservicesFramework.Trancing.Jaeger.Options;
using MicroservicesFramework.Common;

namespace MicroservicesFramework.Trancing.Jaeger;

public static class JeagerExtensions
{
    public static IServiceCollection AddJeager(this IServiceCollection services)
    {
        var options = services.GetOptions<TracingOptions>("tracing");

        if (options is null 
            || !options.Enabled
            || options.Jaeger is null 
            || !options.Jaeger.Enabled)
        {
            return services;
        }

        services.AddOpenTracing();
        services.AddSingleton<ITracer>(sp =>
        {
            var serviceName = sp.GetRequiredService<IWebHostEnvironment>().ApplicationName;
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            var jeagerOptions = options.Jaeger;
            var maxPacketSize = jeagerOptions.MaxPacketSize;

            Configuration.SenderConfiguration.DefaultSenderResolver = JeagerConfigurator.DefaultSenderResolver(loggerFactory);

            var sender = JeagerConfigurator.Sender(jeagerOptions, maxPacketSize);
            var sampler = JeagerConfigurator.Sampler(jeagerOptions, maxPacketSize);

            var reporter = new RemoteReporter.Builder()
                .WithSender(sender)
                .WithLoggerFactory(loggerFactory)
                .Build();

            var tracer = new Tracer.Builder(serviceName)
                .WithLoggerFactory(loggerFactory)
                .WithReporter(reporter)
                .WithSampler(sampler)
                .Build();

            GlobalTracer.Register(tracer);

            return tracer;
        });

        return services;
    }
}
