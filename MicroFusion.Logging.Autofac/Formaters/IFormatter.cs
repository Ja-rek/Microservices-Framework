using Castle.DynamicProxy;

namespace MicroFusion.Logging.Autofac.Formaters;

public interface IFormatter
{
    string Format(IInvocation invocation);
}
