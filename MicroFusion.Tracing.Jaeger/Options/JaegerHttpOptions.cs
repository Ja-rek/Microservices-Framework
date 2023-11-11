namespace MicroFusion.Trancing.Jaeger.Options;

public sealed class JaegerHttpOptions
{
    public bool Enabled { get; set; }
    public string? Endpoint { get; set; }
    public string? AuthToken { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? UserAgent { get; set; }
}
