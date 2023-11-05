using Castle.DynamicProxy;

namespace MicroservicesFramework.Logging.Autofac.Formaters;

public interface IFormatter
{
    string Format(IInvocation invocation);
}
