using static MicroservicesFramework.Tracing.Jeager.IHttpSender;
using Jaeger.Senders.Thrift;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Jaeger.Senders;

namespace MicroservicesFramework.Tracing.Jeager
{
    public class HttpSenderAdapter : IHttpSender
    {
        public IHttpSenderBuilder Create(string endpoint)
        {
            return new HttpSenderBuilderAdapter(new HttpSender.Builder(endpoint));
        }

        private class HttpSenderBuilderAdapter : IHttpSenderBuilder
        {
            private readonly HttpSender.Builder _builder;

            public HttpSenderBuilderAdapter(HttpSender.Builder builder)
            {
                _builder = builder;
            }

            public IHttpSenderBuilder WithMaxPacketSize(int maxPacketSizeBytes)
            {
                _builder.WithMaxPacketSize(maxPacketSizeBytes);
                return this;
            }

            public IHttpSenderBuilder WithAuth(string username, string password)
            {
                _builder.WithAuth(username, password);
                return this;
            }

            public IHttpSenderBuilder WithAuth(string authToken)
            {
                _builder.WithAuth(authToken);
                return this;
            }

            public IHttpSenderBuilder WithHttpHandler(HttpClientHandler httpHandler)
            {
                _builder.WithHttpHandler(httpHandler);
                return this;
            }

            public IHttpSenderBuilder WithCertificates(X509CertificateCollection certificates)
            {
                // Implement as needed
                return this;
            }

            public IHttpSenderBuilder WithUserAgent(string userAgent)
            {
                _builder.WithUserAgent(userAgent);
                return this;
            }

            public ISender Build()
            {
                return _builder.Build();
            }
        }
    }
}

