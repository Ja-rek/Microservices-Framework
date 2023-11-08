using FluentAssertions;
using Microsoft.Extensions.Hosting;
using MicroservicesFramework.Common;
using MicroservicesFramework.Logging.Options;
using MicroservicesFramework.Logging;
using Serilog;
using Serilog.Events;

namespace microservicesframework.logging.unittests;

public class LoggerConfiguratorTests
{
    [Test]
    public void ConfigureLogger_WithNullOptions_DoesNotThrow()
    {
        // Arrange
        LoggerOptions loggerOptions = null;
        LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
        AppOptions appOptions = new AppOptions();
        var context = new HostBuilderContext(new Dictionary<object, object>());

        // Act and Assert
        Assert.DoesNotThrow(() => LoggerConfigurator.ConfigureLogger(context, loggerConfiguration, loggerOptions, appOptions));
    }

    [Test]
    public void ConfigureLogger_WithEmptyLogLevel_ThrowsException()
    {
        // Arrange
        var loggerOptions = new LoggerOptions { Level = "" };
        var loggerConfiguration = new LoggerConfiguration();
        var appOptions = new AppOptions();
        var context = new HostBuilderContext(new Dictionary<object, object>());

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => LoggerConfigurator.ConfigureLogger(context, loggerConfiguration, loggerOptions, appOptions));
    }
}

