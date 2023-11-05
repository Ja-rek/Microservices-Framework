using Castle.DynamicProxy;
using System.Reflection;
using System.Text;

namespace MicroservicesFramework.Logging.Autofac.Formaters;

public class ParametersFormatter : IFormatter
{
    public string Format(IInvocation invocation)
    {
        var parameters = new StringBuilder();
        foreach (var parameter in invocation.Method.GetParameters())
        {
            if (parameters.Length > 0)
                parameters.Append(", ");
            parameters.Append($"{FormatParameter(parameter)}");
        }
        return parameters.ToString();
    }

    private string FormatParameter(ParameterInfo parameter)
    {
        var formattedGenericType = FormatGenericType(parameter.ParameterType);
        var formattedDefaultValue = FormatDefaultValue(parameter);
        var parameterName = parameter.Name;

        return $"{formattedGenericType} {parameterName + formattedDefaultValue}";
    }

    private string FormatDefaultValue(ParameterInfo parameter)
    {
        return parameter.HasDefaultValue
            ? $" = {parameter.DefaultValue}"
            : string.Empty;
    }

    private string FormatGenericType(Type type)
    {
        if (type.IsGenericType)
        {
            var genericArguments = string.Join(", ", type.GetGenericArguments().Select(x => x.Name));
            return $"{type.Name.Split('`')[0]}<{genericArguments}>";
        }

        return type.Name;
    }
}
