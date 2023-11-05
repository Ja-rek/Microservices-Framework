using Castle.DynamicProxy;

namespace MicroservicesFramework.Logging.Autofac.Formaters;

public class MethodSignatureFormatter : IFormatter
{
    public string Format(IInvocation invocation)
    {
        var targetType = invocation.TargetType;
        return $"{targetType?.Name}.{invocation.Method.Name}";
    }
}
