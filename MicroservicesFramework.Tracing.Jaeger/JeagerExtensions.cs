using Jaeger;
using Jaeger.Reporters;
using OpenTracing;
using OpenTracing.Util;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using MicroservicesFramework.Trancing.Jaeger.Options;
using MicroservicesFramework.Common;
using MicroservicesFramework.Tracing.Jeager;
using Microsoft.Extensions.Configuration;

namespace MicroservicesFramework.Trancing.Jaeger;

public static class JeagerExtensions
{
    public static IServiceCollection AddJeager(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<TracingOptions>(configuration.GetSection("Tracing"));

        var options = services.GetOptions<TracingOptions>();

        if (options is null || !options.Enabled
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

            var httpSenderAdapter = new HttpSenderAdapter(); 
            var sender = JeagerConfigurator.Sender(jeagerOptions, httpSenderAdapter);
            var sampler = JeagerConfigurator.Sampler(jeagerOptions);

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
