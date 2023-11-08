namespace MicroservicesFramework.Trancing.Jaeger.Options;

public sealed class TracingOptions
{
    public bool Enabled { get; set; }
    public JaegerOptions? Jaeger { get; set; }
}
