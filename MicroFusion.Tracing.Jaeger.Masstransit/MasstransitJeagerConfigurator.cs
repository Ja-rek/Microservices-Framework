using OpenTelemetry.Resources;
using OpenTelemetry.Exporter;
using MicroFusion.Common;

namespace MicroFusion.Tracing.Jaeger.Masstransit;

internal sealed class MasstransitJeagerConfigurator
{
    public static Action<ResourceBuilder> ConfigureResource(AppOptions? appOptions)
    {
        if (appOptions is null)
        {
            throw new InvalidOperationException("You should set the app options.");
        }

        if (string.IsNullOrWhiteSpace(appOptions.Name))
        {
            throw new InvalidOperationException("You should set the app name.");
        }

        return (ResourceBuilder r) => r.AddService(appOptions.Name,
                 serviceVersion: appOptions.Version,
                 serviceInstanceId: appOptions.Instance);
    }

    public static OtlpExportProtocol MapProtocol(string? protocol)
    {
        if (string.IsNullOrWhiteSpace(protocol))
        {
            throw new InvalidOperationException("You should set protocol.");
        }

        if (!Enum.TryParse(protocol, out OtlpExportProtocol protocolEnum))
        {
            throw new InvalidOperationException("You should use 'Grpc' or 'HttpProtobuf' protocol.");
        }

        return protocolEnum;
    }

    public static Uri? MapEndpoint(string? endpoint)
    {
        if (string.IsNullOrWhiteSpace(endpoint))
        {
            throw new InvalidOperationException("You should set endpoint.");
        }

        return new Uri(endpoint);
    }
}