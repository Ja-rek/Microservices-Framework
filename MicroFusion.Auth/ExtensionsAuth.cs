using MicroFusion.Auth.Options;
using MicroFusion.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MicroFusion.Auth;

public static class ExtensionsAuth
{
    public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<AuthOptions>(configuration.GetSection("Auth"));

        var options = services.GetOptions<AuthOptions>();

        if (options is null || !options.Enabled)
        {
            return services;
        }

        var authority = options.Authority == string.Empty ? null : options.Authority;

        services
            .AddAuthorization()
            .AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = authority;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

        return services;
    }

    public static WebApplication UseAuth(this WebApplication app)
    {
        app.UseAuthentication()
            .UseAuthorization();

        return app;
    }
}
