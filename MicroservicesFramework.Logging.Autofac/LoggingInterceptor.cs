using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MicroservicesFramework.Logging.Autofac;

public class LoggingInterceptor : IInterceptor
{
    private readonly ILogger<LoggingInterceptor> logger;

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        this.logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
        var parameters = string.Join(", ", invocation.Method.GetParameters().Select(FormatParameterName));
        var targetType = invocation.TargetType;
        var method = $"{targetType?.Name}.{invocation.Method.Name}({parameters})";
        var @namespace = targetType?.Namespace;
        var arguments = invocation.Arguments;

        logger.LogInformation("Call method '{namespace}.{method}' with parameters '{@parameters}'.", @namespace, method, arguments);

        try
        {
            invocation.Proceed();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in method '{namespace}.{method}'.", @namespace, method);
            throw;
        }

        logger.LogInformation("Method '{namespace}.{method}' has executed. Result: '{@result}'.", @namespace, method, invocation.ReturnValue);
    }

    public static string FormatParameterName(ParameterInfo parameter)
    {
        var formattedGenericType = FormatGenericType(parameter.ParameterType);
        var formattedDefaultValue = FormatDefaultValue(parameter);
        var parameterName = parameter.Name;

        return $"{formattedGenericType} {parameterName + formattedDefaultValue}";
    }

    private static string FormatDefaultValue(ParameterInfo parameter)
    {
        return parameter.HasDefaultValue
            ? $" = {parameter.DefaultValue}"
            : string.Empty;
    }

    private static string FormatGenericType(Type type)
    {
        if (type.IsGenericType)
        {
            string genericArguments = type.GetGenericArguments()
                .Select(x => x.Name)
                .Aggregate((x1, x2) => $"{x1}, {x2}");

            return $"{type.Name.Substring(0, type.Name.IndexOf("`"))}"
                 + $"<{genericArguments}>";
        }

        return type.Name;
    }

}
