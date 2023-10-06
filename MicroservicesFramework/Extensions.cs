using MicroservicesFramework.Logging;
using MicroservicesFramework.Mediator;
using Microsoft.AspNetCore.Builder;

namespace MicroservicesFramework;

public static class Extensions
{
    public static void UseMicroservicesFramework(this WebApplicationBuilder builder, params Type[] servicesForMediator)
    {
        builder.UseLogger();
        builder.UseMediator(servicesForMediator);
    }
}
