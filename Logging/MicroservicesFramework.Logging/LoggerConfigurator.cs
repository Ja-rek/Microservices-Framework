using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MicroservicesFramework.Logging.Options;

namespace MicroservicesFramework.Logging;

internal class LoggerConfigurator
{
    public static void ConfigureLogger(HostBuilderContext context, LoggerConfiguration config)
    {
        var options = context.Configuration.GetOptions<LoggerOption>("logger");
        if (options is null)
        {
            return;
        }

        ConfigureLogLevel(options, config);
        ConfigureConsole(options, config);
        ConfigureSaveToFile(options, config);
        ConfigureSeq(options, config);
        ConfigureSaveToFile(options, config);
        ConfigureExcludePath(options, config);
        ConfigureEnrich(context, config);
    }

    private static void ConfigureLogLevel(LoggerOption options, LoggerConfiguration config)
    {
        if (string.IsNullOrWhiteSpace(options.Level))
        {
            throw new InvalidOperationException("Set log level for logger in appsettings.json.");
        }

        var logLevel = Enum.Parse<LogEventLevel>(options.Level, true);
        var loggingLevelSwitch = new LoggingLevelSwitch(logLevel);

        config.MinimumLevel.ControlledBy(loggingLevelSwitch);
    }

    private static void ConfigureConsole(LoggerOption options, LoggerConfiguration config)
    {
        var console = options?.Console;
        if (console is not null && console.Enabled is true)
        {
            config.WriteTo.Console();
        }
    }

    private static void ConfigureSaveToFile(LoggerOption options, LoggerConfiguration config)
    {
        var file = options?.File;
        if (file is not null && file.Enabled is true)
        {
            if (string.IsNullOrWhiteSpace(file.Path))
            {
                throw new InvalidOperationException("Set file path for logger in appsettings.json.");
            }

            if (!Enum.TryParse<RollingInterval>(file.Interval, true, out var interval))
            {
                interval = RollingInterval.Day;
            }

            config.WriteTo.File(file.Path, rollingInterval: interval);
        }
    }

    private static void ConfigureSeq(LoggerOption options, LoggerConfiguration config)
    {
        var seq = options?.Seq;
        var url = seq?.Url;
        var apiKey = seq?.ApiKey;

        if (seq is not null && seq.Enabled is true)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new InvalidOperationException("Set Seq url for logger in appsettings.json.");
            }

            if (!string.IsNullOrEmpty(apiKey))
            {
                config.WriteTo.Seq(url, apiKey: apiKey);
            }
            else
            {
                config.WriteTo.Seq(url);
            }
        }
    }

    private static void ConfigureExcludePath(LoggerOption options, LoggerConfiguration config)
    {
        var excludePaths = options?.ExcludePaths ?? Enumerable.Empty<string>();
        foreach (var excludePath in excludePaths)
        {
            if (!string.IsNullOrWhiteSpace(excludePath))
            {
                config.Filter.ByExcluding(Matching.WithProperty<string>("RequestPath", n => n.Contains(excludePath)));
            }
        }
    }

    private static void ConfigureEnrich(HostBuilderContext context, LoggerConfiguration config)
    {
        var option = context.Configuration.GetOptions<AppOption>("app");

        config.Enrich.FromLogContext();
        var TryAddEnrichWithProperty = (string name, string? value) =>
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                config.Enrich.WithProperty(name, value);
            }
        };

        TryAddEnrichWithProperty("Application", option?.Name);
        TryAddEnrichWithProperty("Instance", option?.Instance);
        TryAddEnrichWithProperty("Cluster", option?.Cluster);
        TryAddEnrichWithProperty("Version", option?.Version);

        TryAddEnrichWithProperty("Environment", context.HostingEnvironment.EnvironmentName);
    }
}

public static class OptionsExtensions
{
    public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
        where TModel : new()
    {
        var model = new TModel();
        configuration.GetSection(sectionName).Bind(model);
        return model;
    }
}
