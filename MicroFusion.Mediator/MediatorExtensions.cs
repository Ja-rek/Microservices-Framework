﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace MicroFusion.Mediator;

public static class MediatorExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services, params Type[] servicesForMediator)
    {
        foreach (var service in servicesForMediator)
        {
            TryAddHandlers(service);
        }

        services.AddSingleton<IMediator>(provider => new Mediator(provider));

        return services;
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

            if (IsValidMessageType(messageType))
            {
                continue;
            }

            if (!MethodLocator.Methods.TryAdd(messageType, new MethodLocation(method, serviceType)))
            {
                throw new InvalidOperationException($"Message '{messageType.Name}' must have one handler method.");
            }
        }
    }

    private static bool IsValidMessageType(Type messageType)
    {
        var interfaces = messageType.GetInterfaces();

        return interfaces.Contains(typeof(IQuery<>))
               || interfaces.Contains(typeof(ICommand<>))
               || interfaces.Contains(typeof(ICommand));
    }
}