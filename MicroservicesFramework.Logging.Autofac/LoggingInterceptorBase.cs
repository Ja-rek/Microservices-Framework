using Castle.DynamicProxy;

namespace MicroservicesFramework.Logging.Autofac;

public abstract class LoggingInterceptorBase : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        LogBefore(invocation);
        try
        {
            invocation.Proceed();
            LogAfter(invocation);
        }
        catch (Exception ex)
        {
            LogError(invocation, ex);
            throw;
        }
    }

    protected abstract void LogBefore(IInvocation invocation);
    protected abstract void LogAfter(IInvocation invocation);
    protected abstract void LogError(IInvocation invocation, Exception exception);
}
