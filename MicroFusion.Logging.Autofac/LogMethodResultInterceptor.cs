using Castle.DynamicProxy;
using MicroFusion.Logging.Autofac.Formaters;
using Microsoft.Extensions.Logging;

namespace MicroFusion.Logging.Autofac;

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
    }

    protected override void LogAfter(IInvocation invocation)
    {
        var methodSignature = methodSignatureFormatter.Format(invocation);
        logger.LogInformation("Method '{methodSignature}' has executed. Result: {@result}.", methodSignature, invocation.ReturnValue);
    }

    protected override void LogError(IInvocation invocation, Exception exception)
    {
    }
}
