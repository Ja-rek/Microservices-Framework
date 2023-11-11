namespace MicroFusion.Logging.Options;

public class LoggerOptions
{
    public string? Level { get; set; }
    public IEnumerable<string>? ExcludePaths { get; set; }
    public ConsoleOptions? Console { get; set; }
    public FileOptions? File { get; set; }
    public SeqOptions? Seq { get; set; }
}
