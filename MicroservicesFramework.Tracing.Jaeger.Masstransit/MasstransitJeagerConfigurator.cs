using OpenTelemetry.Resources;
using MicroservicesFramework.Logging.Options;
using OpenTelemetry.Exporter;

namespace MicroservicesFramework.Tracing.Jaeger.Masstransit;

internal sealed class MasstransitJeagerConfigurator
{
    public static Action<ResourceBuilder> ConfigureResource(AppOptions appOptions)
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
        if (!Enum.TryParse(protocol, out OtlpExportProtocol protocolEnum))
        {
            throw new InvalidOperationException("You should use 'Grpc' or 'HttpProtobuf' protocol.");
        }

        return protocolEnum;
    }

    public static Uri? MapEndpoint(string? endpoint)
    {
        return endpoint == string.Empty || endpoint == null
            ? null 
            : new Uri(endpoint);
    }
}