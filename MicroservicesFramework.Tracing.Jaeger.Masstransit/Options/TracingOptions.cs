namespace MicroservicesFramework.Tracing.Jaeger.Masstransit.Options;

public class TracingOptions
{
    public bool Enabled { get; set; }
    public JaegerOptions? Jaeger { get; set; }
}
