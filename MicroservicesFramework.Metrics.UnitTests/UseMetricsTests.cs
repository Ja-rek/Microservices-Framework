using MicroservicesFramework.Metrics.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using FluentAssertions;
using App.Metrics.AspNetCore;

namespace MicroservicesFramework.Metrics.UnitTests;

[TestFixture]
public class UseMetricsTests
{
    [Test]
    public void UseMetrics_WhenMetricOptionsEnable_RegisterMetrics()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder();
        var serv = WebApplication.CreateBuilder().Services;
        var services = builder.Services;

        var metricOptions = new MetricsOptions
        {
            Enabled = true,
            EnablePrometheus = true
        };

        services.AddSingleton<IOptions<MetricsOptions>>(new OptionsWrapper<MetricsOptions>(metricOptions));

        // Act
        builder.UseMetrics();

        // Assert
        services.Should().Contain(x => x.ServiceType == typeof(IMetricsResponseWriter));
    }

    [Test]
    public void UseMetrics_WhenMetricOptionsdisable_RegisterMetrics()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder();
        var services = builder.Services;

        var metricOptions = new MetricsOptions
        {
            Enabled = false,
            EnablePrometheus = true
        };

        services.AddSingleton<IOptions<MetricsOptions>>(new OptionsWrapper<MetricsOptions>(metricOptions));

        // Act
        builder.UseMetrics();

        // Assert
        services.Should().NotContain(x => x.ServiceType == typeof(IMetricsResponseWriter));
    }
} 