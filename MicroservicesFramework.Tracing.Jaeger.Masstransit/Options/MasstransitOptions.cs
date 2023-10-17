namespace MicroservicesFramework.Tracing.Jaeger.Masstransit.Options;

public class MasstransitOptions
{
    public bool Enabled { get; set; }
    public string? Endpoint { get; set; }
    public string? Protocol { get; set; }
}
