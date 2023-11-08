using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MicroservicesFramework.Common;

public static class OptionsExtensions
{
    public static T? GetOptions<T>(this IServiceCollection services)
        where T : class
    {
        return services.BuildServiceProvider().GetRequiredService<IOptions<T>>()
            ?.Value;
    }
}