using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace MicroservicesFramework.Mediator;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services, params Type[] types)
    {
        foreach (var type in types)
        {
            TryAddHandlers(type);
        }

        return services.AddSingleton<IMediator>(provider => new Mediator(provider));
    }

    public static void TryAddHandlers(Type serviceType)
    {
        var methods = serviceType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        if (methods is null)
        {
            return;
        }

        foreach (var method in methods)
        {
            if (method is null)
            {
                continue;
            }

            var messageType = method.GetParameters()
                .FirstOrDefault()
                ?.ParameterType;

            if (messageType == null)
            {
                continue;
            }

            var interfaces = messageType.GetInterfaces();
            if (!(interfaces.Contains(typeof(IQuery<>)) || !interfaces.Contains(typeof(ICommand<>)) || !interfaces.Contains(typeof(ICommand))))
            {
                continue;
            }

            if (!MethodLocator.Methods.TryAdd(messageType, new MethodLocation(method, serviceType)))
            {
                throw new InvalidOperationException($"Message '{messageType.Name}' must have one handler method.");
            }
        }
    }
}