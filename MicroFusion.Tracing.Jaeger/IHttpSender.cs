using Jaeger.Senders;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace MicroFusion.Tracing.Jeager;

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
    IHttpSenderBuilder WithCertificates(IEnumerable<X509Certificate> certificates);
    IHttpSenderBuilder WithUserAgent(string userAgent);
    ISender Build();
}
