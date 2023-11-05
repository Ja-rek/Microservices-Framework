using Castle.DynamicProxy;

namespace MicroservicesFramework.Logging.Autofac.Formaters;

public class ResultFormatter : IFormatter
{
    public string Format(IInvocation invocation)
    {
        return invocation.ReturnValue?.ToString() ?? "null";
    }
}
