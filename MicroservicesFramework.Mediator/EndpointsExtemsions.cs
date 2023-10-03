using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesFramework.Mediator;

public static class EndpointsExtemsions
{
    public static RouteHandlerBuilder MapGet<T, T2>(this WebApplication app, string pattern)
        where T2 : class
        where T : IQuery<T2>
    {
        return app.MapGet(pattern, async (IMediator mediator, [AsParameters] T cmd) =>
        {
            var result = await mediator.Send(cmd);
            if (result != null)
            {
                return Results.Ok(result);
            }

            return Results.NoContent();
        }).AddFluentValidationFilter();
    }

    public static RouteHandlerBuilder MapPost<T>(this WebApplication app, string pattern) where T : ICommand
    {
        return app.MapPost(pattern, async (IMediator mediator, [FromBody] T cmd) =>
        {
            await mediator.Send(cmd);
            return Results.Created(pattern, cmd);

        }).AddFluentValidationFilter();
    }

    public static RouteHandlerBuilder MapPut<T>(this WebApplication app, string pattern) where T : ICommand
    {
        return app.MapPut(pattern, async (IMediator mediator, [FromBody] T cmd) =>
        {
            await mediator.Send(cmd);
            return Results.NoContent();
        }).AddFluentValidationFilter();
    }

    public static RouteHandlerBuilder MapPatch<T>(this WebApplication app, string pattern) where T : ICommand
    {
        return app.MapPatch(pattern, async (IMediator mediator, [FromBody] T cmd) =>
        {
            await mediator.Send(cmd);
            return Results.NoContent();
        }).AddFluentValidationFilter();
    }

    public static RouteHandlerBuilder MapDelete<T>(this WebApplication app, string pattern) where T : ICommand
    {
        return app.MapDelete(pattern, async (IMediator mediator, [FromBody] T cmd) =>
        {
            await mediator.Send(cmd);
            return Results.NoContent();
        }).AddFluentValidationFilter();
    }
}
