using Autofac;
using Autofac.Extras.DynamicProxy;
using MicroservicesFramework;
using MicroservicesFramework.Logging.Autofac;
using MicroservicesFramework.Mediator;
using Microsoft.eShopOnContainers.Services.Ordering.API.Application.Queries;
using Shop.Orders.Application.Commands.CancelOrder;
using Shop.Orders.Application.Queries.GetOrder;
using Shop.Orders.Application.Queries.GetOrderFromUser;
using Shop.Orders.Application.Queries.Resources;
using Shop.Orders.Infrastructure.Mongo;
using Shop.Orders.Infrastructure.Mongo.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.UseMicroservicesFramework();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMicroservicesFramework();

builder.Host.ConfigureContainer<ContainerBuilder>(builder => 
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


var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapGet<GetOrderFromUserQuery, OrderResource>("Order")
    .RequireAuthorization();

app.Run();
