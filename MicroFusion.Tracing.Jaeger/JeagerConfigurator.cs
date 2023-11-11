using Jaeger.Samplers;
using Jaeger.Senders;
using Jaeger.Senders.Thrift;
using MicroFusion.Tracing.Jeager;
using MicroFusion.Trancing.Jaeger.Options;
using Microsoft.Extensions.Logging;
using System;

namespace MicroFusion.Trancing.Jaeger;

internal sealed class JeagerConfigurator
{
    public static SenderResolver DefaultSenderResolver(ILoggerFactory loggerFactory)
    {
        return new SenderResolver(loggerFactory)
            .RegisterSenderFactory<ThriftSenderFactory>();
    }

    public static ISender Sender(JaegerOptions options, IHttpSender httpSender)
    {
        if (HasConflictingSenderOptions(options))
        {
            throw new InvalidOperationException("You should use only one sender protocol.");
        }

        if (options.Http is not null && options.Http.Enabled)
        {
            return HttpSender(options.Http, options.MaxPacketSize, httpSender);
        }

        if (options.Udp is not null && options.Udp.Enabled)
        {
            var udp = options.Udp;
            return new UdpSender(
                udp.Host,
                udp.Port,
                options.MaxPacketSize);
        }

        throw new InvalidOperationException("You should set sender protocol.");
    }

    private static ISender HttpSender(JaegerHttpOptions options, int maxPacketSize, IHttpSender httpSender)
    {
        if (string.IsNullOrWhiteSpace(options.Endpoint))
        {
            throw new Exception("You should set HTTP sender endpoint.");
        }

        var builder = httpSender.Create(options.Endpoint)
            .WithMaxPacketSize(maxPacketSize);

        if (!string.IsNullOrWhiteSpace(options.Username) && !string.IsNullOrWhiteSpace(options.Password))
        {
            builder.WithAuth(options.Username, options.Password);
        }

        if (!string.IsNullOrWhiteSpace(options.AuthToken))
        {
            builder.WithAuth(options.AuthToken);
        }

        if (!string.IsNullOrWhiteSpace(options.UserAgent))
        {
            builder.WithUserAgent(options.UserAgent);
        }

        return builder.Build();
    }

    public static ISampler Sampler(JaegerOptions options)
    {
        return options.Sampler switch
        {
            "const" => new ConstSampler(true),
            "rate" => new RateLimitingSampler(options.MaxPacketSize),
            "probabilistic" => new ProbabilisticSampler(options.MaxPacketSize),
            _ => new ConstSampler(true),
        }; ;
    }

    private static bool HasConflictingSenderOptions(JaegerOptions options)
    {
        return (options.Http != null && options.Http.Enabled) &&
               (options.Udp != null && options.Udp.Enabled);
    }
}
