namespace MicroFusion.Tracing.Jaeger.Masstransit.Options;

public class JaegerOptions
{
    public bool Enabled { get; set; }
    public MasstransitOptions? Masstransit { get; set; }
}
