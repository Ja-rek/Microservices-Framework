using AutoFixture;
using FluentAssertions;
using MicroFusion.Common;
using MicroFusion.Tracing.Jaeger.Masstransit.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;

namespace MicroFusion.Tracing.Jaeger.Masstransit.UnitTests;

[TestFixture]
public class AddMasstransitToJaegarTests
{
    private  Fixture fixture;
    private IServiceCollection services;
    private WebApplicationBuilder builder;
    private AppOptions appOptions;
    private MasstransitTracingOptions tracingOptions;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        fixture = new Fixture();
    }

    [SetUp]
    public void SetUp()
    {
        builder = WebApplication.CreateBuilder();
        services = builder.Services;

        appOptions = fixture.Create<AppOptions>();
        tracingOptions = fixture.Create<MasstransitTracingOptions>();
        tracingOptions.Enabled = true;
        tracingOptions.Jaeger.Enabled = true;
        tracingOptions.Jaeger.Masstransit.Enabled = true;
    }


    [Test]
    public void AddMasstransitToJaegar_WhenEndpointAndProtocolAreValid_Succeeds()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = "http://example.com";
        tracingOptions.Jaeger.Masstransit.Protocol = "HttpProtobuf";

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        services.AddMasstransitToJaegar(builder.Configuration);
        services.Should().Contain(x => x.ServiceType == typeof(TracerProvider));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenEndpointAndProtocolAreValid_ThrowsNoException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = "http://example.com";
        tracingOptions.Jaeger.Masstransit.Protocol = "HttpProtobuf";

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.DoesNotThrow(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenEndpointIsNull_ThrowsInvalidOperationException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = null;
        tracingOptions.Jaeger.Masstransit.Protocol = "HttpProtobuf";

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenEndpointIsWhiteSpace_ThrowsInvalidOperationException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = " ";
        tracingOptions.Jaeger.Masstransit.Protocol = "HttpProtobuf";

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenEndpointIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = string.Empty;
        tracingOptions.Jaeger.Masstransit.Protocol = "HttpProtobuf";

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenEndpointIsInvalid_ThrowsUriFormatException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = "Invalid";
        tracingOptions.Jaeger.Masstransit.Protocol = "HttpProtobuf";

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.Throws<UriFormatException>(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenProtocolIsNullOrEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = "http://example.com";
        tracingOptions.Jaeger.Masstransit.Protocol = null;

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenProtocolIsWhiteSpace_ThrowsInvalidOperationException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = "http://example.com";
        tracingOptions.Jaeger.Masstransit.Protocol = " ";

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenProtocolIsEmpty_ThrowsInvalidOperationException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit.Endpoint = "http://example.com";
        tracingOptions.Jaeger.Masstransit.Protocol = string.Empty;

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => services.AddMasstransitToJaegar(builder.Configuration));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenTracingOptionsIsNull_NoRegisterTracerProvider()
    {
        // Arrange
        tracingOptions = null;

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        services.Should().NotContain(x => x.ServiceType == typeof(TracerProvider));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenJaegerOptionsIsNull_NoRegisterTracerProvider()
    {
        // Arrange
        tracingOptions.Jaeger = null;
        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        services.Should().NotContain(x => x.ServiceType == typeof(TracerProvider));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenMasstransitOptionsIsNull_ThrowsNoException()
    {
        // Arrange
        tracingOptions.Jaeger.Masstransit = null;

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        services.Should().NotContain(x => x.ServiceType == typeof(TracerProvider));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenTracingOptionsDisabled_NoRegisterTracerProvider()
    {
        // Arrange
        tracingOptions.Enabled = false;
        tracingOptions.Jaeger.Enabled = false;
        tracingOptions.Jaeger.Masstransit.Enabled = false;

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        services.Should().NotContain(x => x.ServiceType == typeof(TracerProvider));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenJaegerOptionsDisabled_NoRegisterTracerProvider()
    {
        // Arrange
        tracingOptions.Enabled = true;
        tracingOptions.Jaeger.Enabled = false;
        tracingOptions.Jaeger.Masstransit.Enabled = true;

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        services.Should().NotContain(x => x.ServiceType == typeof(TracerProvider));
    }

    [Test]
    public void AddMasstransitToJaegar_WhenMasstransitOptionsDisabled_NoRegisterTracerProvider()
    {
        // Arrange
        tracingOptions.Enabled = true;
        tracingOptions.Jaeger.Enabled = true;
        tracingOptions.Jaeger.Masstransit.Enabled = false;

        services.AddSingleton<IOptions<AppOptions>>(new OptionsWrapper<AppOptions>(appOptions));
        services.AddSingleton<IOptions<MasstransitTracingOptions>>(new OptionsWrapper<MasstransitTracingOptions>(tracingOptions));

        // Act & Assert
        services.Should().NotContain(x => x.ServiceType == typeof(TracerProvider));
    }
}