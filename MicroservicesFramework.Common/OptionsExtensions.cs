using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroservicesFramework.Common;

public static class OptionsExtensions
{
    public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
        where TModel : new()
    {
        var model = new TModel();
        configuration.GetSection(sectionName).Bind(model);
        return model;
    }


    public static TModel GetOptions<TModel>(this IServiceCollection services, string sectionName)
        where TModel : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<TModel>(sectionName);

    }
}