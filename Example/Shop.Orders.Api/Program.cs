using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using MicroFusion;
using MicroFusion.Logging.Autofac;
using MicroFusion.Mediator;
using Shop.Orders.Application.Commands;
using Shop.Orders.Application.Commands.CancelOrder;
using Shop.Orders.Application.Queries.GetOrder;
using Shop.Orders.Application.Queries.GetOrderFromUser;
using Shop.Orders.Application.Queries.Resources;
using Shop.Orders.Infrastructure.Mongo;
using Shop.Orders.Infrastructure.Mongo.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddMicroFusion(builder.Configuration, 
        typeof(OrderCommandService), 
        typeof(OrderQueryService));

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder => 
{
builder.RegisterAssemblyTypes(typeof(GetOrderQuery).Assembly)
    .Where(x => x.Name.EndsWith("Service"))
    .AsImplementedInterfaces()
    .EnableInterfaceInterceptors()
    .InterceptedBy(typeof(LogMethodCallInterceptor));

    builder.RegisterType<OrderRepository>()
        .AsImplementedInterfaces();

    builder.RegisterType<MongoCollectionFactory>()
        .AsImplementedInterfaces();
});

builder.UseMicroFusion();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost<CreateOrderCommand>("Order")
    .RequireAuthorization();

app.MapDelete<CancelOrderCommand>("Order")
    .RequireAuthorization();

app.MapPost<AwaitingValidationOrderCommand>("AwaitingValidationOrder")
    .RequireAuthorization();

app.MapPost<CreateOrderDraftCommand>("DrafOrder")
    .RequireAuthorization();

app.MapGet<GetOrderQuery, OrderResource>("Order")
    .RequireAuthorization();

app.MapGet<GetOrderFromUserQuery, OrderResource>("OrderFromUser")
    .RequireAuthorization();

app.Run();
