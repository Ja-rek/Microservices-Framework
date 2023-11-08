namespace MicroservicesFramework.Tracing.Jaeger.Masstransit.Options;

public class MasstransitTracingOptions
{
    public bool Enabled { get; set; }
    public JaegerOptions? Jaeger { get; set; }
}
