namespace MicroservicesFramework.Trancing.Jaeger.Options;

public class TracingOptions
{
    public bool Enabled { get; set; }
    public JaegerOptions? Jaeger { get; set; }
}
