namespace MicroFusion.Trancing.Jaeger.Options;

public sealed class JaegerUdpOptions
{
    public bool Enabled { get; set; }
    public string? Host { get; set; }
    public int Port { get; set; }
}
