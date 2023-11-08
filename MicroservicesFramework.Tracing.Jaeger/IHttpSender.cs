using Jaeger.Senders;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace MicroservicesFramework.Tracing.Jeager;

public interface IHttpSender
{
    IHttpSenderBuilder Create(string endpoint);
}

public interface IHttpSenderBuilder
{
    IHttpSenderBuilder WithMaxPacketSize(int maxPacketSizeBytes);
    IHttpSenderBuilder WithAuth(string username, string password);
    IHttpSenderBuilder WithAuth(string authToken);
    IHttpSenderBuilder WithHttpHandler(HttpClientHandler httpHandler);
    IHttpSenderBuilder WithCertificates(X509CertificateCollection certificates);
    IHttpSenderBuilder WithUserAgent(string userAgent);
    ISender Build();
}
