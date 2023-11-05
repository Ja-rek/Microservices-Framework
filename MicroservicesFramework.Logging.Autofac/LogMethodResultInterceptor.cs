using Castle.DynamicProxy;
using MicroservicesFramework.Logging.Autofac.Formaters;
using Microsoft.Extensions.Logging;

namespace MicroservicesFramework.Logging.Autofac;

public class LogMethodResultInterceptor : LoggingInterceptorBase
{
    private readonly ILogger<LogMethodResultInterceptor> logger;
    private readonly IFormatter methodSignatureFormatter;

    public LogMethodResultInterceptor(ILogger<LogMethodResultInterceptor> logger,
        IFormatter methodSignatureFormatter)
    {
        this.logger = logger;
        this.methodSignatureFormatter = methodSignatureFormatter;
    }

    protected override void LogBefore(IInvocation invocation)
    {
        // Log method result interception-specific logic here (if needed)
    }

    protected override void LogAfter(IInvocation invocation)
    {
        var methodSignature = methodSignatureFormatter.Format(invocation);
        logger.LogInformation("Method '{methodSignature}' has executed. Result: {@result}.", methodSignature, invocation.ReturnValue);
    }

    protected override void LogError(IInvocation invocation, Exception exception)
    {
        // Log error interception-specific logic here (if needed)
    }
}
