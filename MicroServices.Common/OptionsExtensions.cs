using Microsoft.Extensions.Configuration;

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
}