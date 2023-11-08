namespace MicroservicesFramework.Trancing.Jaeger.Options;

public sealed class JaegerOptions
{
    public bool Enabled { get; set; }
    public JaegerUdpOptions? Udp { get; set; }
    public JaegerHttpOptions? Http { get; set; }
    public int MaxPacketSize { get; set; } = 1048576;
    public string? Sampler { get; set; }
}
