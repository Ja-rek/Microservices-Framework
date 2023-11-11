using Castle.DynamicProxy;
using MicroFusion.Logging.Autofac.Formaters;
using Microsoft.Extensions.Logging;

namespace MicroFusion.Logging.Autofac;

public class LogMethodCallInterceptor : LoggingInterceptorBase
{
    private readonly ILogger<LogMethodCallInterceptor> logger;
    private readonly IFormatter parametersFormatter;
    private readonly IFormatter methodSignatureFormatter;

    public LogMethodCallInterceptor(ILogger<LogMethodCallInterceptor> logger,
        IFormatter parametersFormatter,
        IFormatter methodSignatureFormatter)
    {
        this.logger = logger;
        this.parametersFormatter = parametersFormatter;
        this.methodSignatureFormatter = methodSignatureFormatter;
    }

    protected override void LogBefore(IInvocation invocation)
    {
        var parameters = parametersFormatter.Format(invocation);
        var methodSignature = methodSignatureFormatter.Format(invocation);

        logger.LogInformation("Call method '{methodSignature}' with parameters {@parameters}.", methodSignature, parameters);
    }

    protected override void LogAfter(IInvocation invocation)
    {
        var methodSignature = methodSignatureFormatter.Format(invocation);
        logger.LogInformation("Method '{methodSignature}' has executed. Result: {@result}.", methodSignature, invocation.ReturnValue);
    }

    protected override void LogError(IInvocation invocation, Exception exception)
    {
        var methodSignature = methodSignatureFormatter.Format(invocation);
        logger.LogError(exception, "Error in method '{methodSignature}'.", methodSignature);
    }
}
