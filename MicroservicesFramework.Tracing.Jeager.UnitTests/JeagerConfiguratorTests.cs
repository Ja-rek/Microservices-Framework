using MicroservicesFramework.Trancing.Jaeger;
using MicroservicesFramework.Trancing.Jaeger.Options;
using Moq;
using Jaeger.Senders.Thrift;
using MicroservicesFramework.Tracing.Jeager;
using FluentAssertions;

namespace MicroservicesFramework.Tracing.Jaeger.Tests;

[TestFixture]
public class JeagerConfiguratorTests
{
    private Mock<IHttpSender> httpSenderMock;
    private Mock<IHttpSenderBuilder> httpSenderBuilderMock;

    [SetUp]
    public void Setup()
    {
        httpSenderMock = new Mock<IHttpSender>();
        httpSenderBuilderMock = new Mock<IHttpSenderBuilder>();

        httpSenderMock
            .Setup(sender => sender.Create(It.IsAny<string>()))
            .Returns(httpSenderBuilderMock.Object);

        httpSenderBuilderMock
            .Setup(sender => sender.WithMaxPacketSize(It.IsAny<int>()))
            .Returns(httpSenderBuilderMock.Object);
    }

    [Test]
    public void Sender_WithNoSenderOptions_ThrowsInvalidOperationException()
    {
        // Arrange
        var options = new JaegerOptions();

        // Act and Assert
        Action act = () => JeagerConfigurator.Sender(options, httpSenderMock.Object);
        act.Should().Throw<InvalidOperationException>().WithMessage("You should set sender protocol.");
    }

    [Test]
    public void Sender_WithConflictingSenderOptions_ThrowsInvalidOperationException()
    {
        // Arrange
        var options = new JaegerOptions
        {
            Http = new JaegerHttpOptions { Enabled = true },
            Udp = new JaegerUdpOptions { Enabled = true }
        };

        // Act and Assert
        Action act = () => JeagerConfigurator.Sender(options, httpSenderMock.Object);
        act.Should().Throw<InvalidOperationException>().WithMessage("You should use only one sender protocol.");
    }

    [Test]
    public void Sender_WithUdpSenderOption_ReturnsUdpSender()
    {
        // Arrange
        var options = new JaegerOptions
        {
            Udp = new JaegerUdpOptions { Enabled = true },
            MaxPacketSize = 1024
        };

        // Act
        var sender = JeagerConfigurator.Sender(options, httpSenderMock.Object);

        // Assert
        sender.Should().BeOfType<UdpSender>();
    }

    [Test]
    public void Sender_ConfiguresHttpSenderWithCorrectProperties_PropertiesSeted()
    {
        // Arrange
        var jaegerOptions = new JaegerOptions
        {
            Http = new JaegerHttpOptions
            {
                Enabled = true,
                Endpoint = "http://example.com",
                Username = "user",
                Password = "password",
                AuthToken = "token",
                UserAgent = "user-agent",
            },
            MaxPacketSize = 1024
        };

        // Act
        var sender = JeagerConfigurator.Sender(jaegerOptions, httpSenderMock.Object);

        // Assert
        httpSenderMock.Verify(sender => sender.Create(jaegerOptions.Http.Endpoint), Times.Once);
        httpSenderBuilderMock.Verify(builder => builder.WithMaxPacketSize(jaegerOptions.MaxPacketSize), Times.Once);
        httpSenderBuilderMock.Verify(builder => builder.WithAuth(jaegerOptions.Http.Username, jaegerOptions.Http.Password), Times.Once);
        httpSenderBuilderMock.Verify(builder => builder.WithAuth(jaegerOptions.Http.AuthToken), Times.Once);
        httpSenderBuilderMock.Verify(builder => builder.WithUserAgent(jaegerOptions.Http.UserAgent), Times.Once);
    }

    [Test]
    [TestCaseSource(nameof(FailTestCases))]
    public void Sender_ConfiguresHttpSenderWithIncorrectProperties_PropertiesNotSeted(JaegerOptions jaegerOptions)
    {
        // Act
        var sender = JeagerConfigurator.Sender(jaegerOptions, httpSenderMock.Object);

        // Assert
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        httpSenderMock.Verify(sender => sender.Create(jaegerOptions.Http.Endpoint), Times.Once);
        httpSenderBuilderMock.Verify(builder => builder.WithMaxPacketSize(jaegerOptions.MaxPacketSize), Times.Once);
        httpSenderBuilderMock.Verify(builder => builder.WithAuth(jaegerOptions.Http.Username, jaegerOptions.Http.Password), Times.Never);
        httpSenderBuilderMock.Verify(builder => builder.WithAuth(jaegerOptions.Http.AuthToken), Times.Never);
        httpSenderBuilderMock.Verify(builder => builder.WithUserAgent(jaegerOptions.Http.UserAgent), Times.Never);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    private static IEnumerable<TestCaseData> FailTestCases()
    {
        yield return new TestCaseData(
            new JaegerOptions
            {
                Http = new JaegerHttpOptions
                {
                    Enabled = true,
                    Endpoint = "http://example.com",
                    Username = null,
                    Password = null,
                    AuthToken = null,
                    UserAgent = null,
                },
                MaxPacketSize = 1024
            });

        yield return new TestCaseData(
            new JaegerOptions
            {
                Http = new JaegerHttpOptions
                {
                    Enabled = true,
                    Endpoint = "http://example.com",
                    Username = "",
                    Password = "",
                    AuthToken = "",
                    UserAgent = "",
                },
                MaxPacketSize = 1024
            });

        yield return new TestCaseData(
            new JaegerOptions
            {
                Http = new JaegerHttpOptions
                {
                    Enabled = true,
                    Endpoint = "http://example.com",
                    Username = "   ",
                    Password = "   ",
                    AuthToken = "   ",
                    UserAgent = "   ",
                },
                MaxPacketSize = 1024
            });
    }
}
