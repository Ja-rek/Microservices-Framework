using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesFramework.Mediator;

public class Mediator : IMediator
{
    private readonly IServiceProvider serviceLocator;

    public Mediator(IServiceProvider serviceLocator)
    {
        this.serviceLocator = serviceLocator;
    }

    public async Task<T?> Send<T>(IMessage<T> cmd)
        where T : class
    {
        var result = InvokeMehtod(cmd);
        if (result is not null && result is Task)
        {
            return await result;
        }

        return result;
    }

    public async Task Send(ICommand cmd)
    {
        var result = InvokeMehtod(cmd);
        if (result is not null && result is Task)
        {
            await result;
        }
    }

    private dynamic? InvokeMehtod(object cmd)
    {
        using (var scope = serviceLocator.CreateScope())
        {
            var cmdType = cmd.GetType();
            if (MethodLocator.Methods.TryGetValue(cmdType, out var location))
            {
                var service = scope.ServiceProvider.GetService(location.ServiceType);
                var @params = new object[] { cmd };

                return location.MethodInfo.Invoke(service, @params);
            }

            return null;
        };
    }
}