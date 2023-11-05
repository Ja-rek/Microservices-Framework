using Jaeger.Samplers;
using Jaeger.Senders;
using Jaeger.Senders.Thrift;
using MicroservicesFramework.Trancing.Jaeger.Options;
using Microsoft.Extensions.Logging;
using System;

namespace MicroservicesFramework.Trancing.Jaeger;

internal sealed class JeagerConfigurator
{

    public static SenderResolver DefaultSenderResolver(ILoggerFactory loggerFactory)
    {
        return new SenderResolver(loggerFactory)
            .RegisterSenderFactory<ThriftSenderFactory>();
    }

    public static ISender Sender(JaegerOptions options, int maxPacketSize)
    {
        if (HasConflictingSenderOptions(options))
        {
            throw new InvalidOperationException("You should use only one sender protocol.");
        }

        if (options.Http is not null && options.Http.Enabled)
        {
            return HttpSender(options.Http, maxPacketSize);
        }

        if (options.Udp is not null && options.Udp.Enabled)
        {
            var udp = options.Udp;
            return new UdpSender(
                udp.Host,
                udp.Port,
                maxPacketSize);
        }

        throw new InvalidOperationException("You should set sender protocol.");
    }

    public static ISender HttpSender(JaegerHtpOptions options, int maxPacketSize)
    {
        if (string.IsNullOrWhiteSpace(options.Endpoint))
        {
            throw new Exception("You should set HTTP sender endpoint.");
        }

        var builder = new HttpSender.Builder(options.Endpoint);

        builder = builder.WithMaxPacketSize(maxPacketSize);

        if (!string.IsNullOrWhiteSpace(options.Username) && !string.IsNullOrWhiteSpace(options.Password))
        {
            builder = builder.WithAuth(options.Username, options.Password);
        }

        if (!string.IsNullOrWhiteSpace(options.AuthToken))
        {
            builder = builder.WithAuth(options.AuthToken);
        }

        if (!string.IsNullOrWhiteSpace(options.UserAgent))
        {
            builder = builder.WithUserAgent(options.Username);
        }

        return builder.Build();
    }

    public static ISampler Sampler(JaegerOptions options, int maxPacketSize)
    {
        return options.Sampler switch
        {
            "const" => new ConstSampler(true),
            "rate" => new RateLimitingSampler(maxPacketSize),
            "probabilistic" => new ProbabilisticSampler(maxPacketSize),
            _ => new ConstSampler(true),
        };
    }

    private static bool HasConflictingSenderOptions(JaegerOptions options)
    {
        return (options.Http != null && options.Http.Enabled) &&
               (options.Udp != null && options.Udp.Enabled);
    }
}
