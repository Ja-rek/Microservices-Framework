namespace MicroservicesFramework.Logging.Options;

public class LoggerOption
{
    public string? Level { get; set; }
    public IEnumerable<string>? ExcludePaths { get; set; }
    public ConsoleOption? Console { get; set; }
    public FileOption? File { get; set; }
    public SeqOption? Seq { get; set; }
}
