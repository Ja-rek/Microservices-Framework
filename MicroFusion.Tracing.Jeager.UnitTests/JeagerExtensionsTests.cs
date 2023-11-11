using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using MicroFusion.Trancing.Jaeger.Options;
using MicroFusion.Trancing.Jaeger;
using Microsoft.AspNetCore.Builder;
using OpenTracing;
using FluentAssertions;

namespace MicroFusion.Tracing.Jaeger.Tests;

[TestFixture]
public class JeagerExtensionsTests
{
    [Test]
    public void AddJeager_WhenJaegerIsDisabled_ShouldNotRegisterITracerService()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder();
        var services = builder.Services;

        // Simulate disabled Jaeger within options
        var options = new TracingOptions
        {
            Enabled = true,
            Jaeger = new JaegerOptions
            {
                Enabled = false
            }
        };

        // Add the options with disabled Jaeger to the services
        services.AddSingleton<IOptions<TracingOptions>>(new OptionsWrapper<TracingOptions>(options));

        // Act
        services.AddJeager(builder.Configuration);

        // Assert
        services.Should().NotContain(x => x.ServiceType == typeof(ITracer));
    }

    [Test]
    public void AddJeager_WhenJaegerIsEnabled_ShouldRegisterITracerService()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder();
        var services = builder.Services;

        // Simulate enabled Jaeger within options
        var options = new TracingOptions
        {
            Enabled = true,
            Jaeger = new JaegerOptions
            {
                Enabled = true
            }
        };

        // Add the options with enabled Jaeger to the services
        services.AddSingleton<IOptions<TracingOptions>>(new OptionsWrapper<TracingOptions>(options));

        // Act
        services.AddJeager(builder.Configuration);

        // Assert
        services.Should().Contain(x => x.ServiceType == typeof(ITracer));
    }

    [Test]
    public void AddJeager_WhenTracingIsDisabled_ShouldNotRegisterITracerService()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder();
        var services = builder.Services;

        // Simulate disabled tracing
        var options = new TracingOptions
        {
            Enabled = false,
            Jaeger = new JaegerOptions
            {
                Enabled = true
            }
        };

        // Add the options with disabled tracing to the services
        services.AddSingleton<IOptions<TracingOptions>>(new OptionsWrapper<TracingOptions>(options));

        // Act
        services.AddJeager(builder.Configuration);

        // Assert
        services.Should().NotContain(x => x.ServiceType == typeof(ITracer));
    }
}

