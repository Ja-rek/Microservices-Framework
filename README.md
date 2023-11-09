# Welcome to MicroFusion !

MicroFusion is a versatile set of utility libraries designed to streamline your web application and microservices development. These libraries can be used independently and are valuable tools for addressing common infrastructural concerns, such as routing, tracing, metrics, and more. MicroFusion also helps in supporting Domain-Driven Design (DDD) and Design by Contract principles, saving you time and effort in managing these critical aspects of your projects.

## Basic Configuration
To get started with MicroFusion, you can simply install the all in one package. This all in one package includes all the individual components, which can also be used independently if desired.

All in one package:
``dotnet add package MicroFusion``
 
 components:

`dotnet add package MicroFusion.Logging`
`dotnet add package MicroFusion.Tracing`
`dotnet add package MicroFusion.Metrics`
and so on.

After installing the package, you can utilize the "UseComponent" and "AddComponent" extension methods as needed for specific components, it's enabling you to customize your configuration within the "appsettings.json" file.

### Configuration all in one:

```csharp
// program.cs
builder.Services
    .AddEndpointsApiExplorer()
    .AddMicroFusion(builder.Configuration, 
        typeof(OrderCommandService), // Command service for Mediator
        typeof(OrderQueryService)); // Query service for Mediator
        
builder.UseMicroFusion();

// Register services with Autofac and enable automatic logging:
builder.RegisterAssemblyTypes(typeof(GetOrderQuery).Assembly)
    .Where(x => x.Name.EndsWith("Service"))
    .AsImplementedInterfaces()
    .EnableInterfaceInterceptors()
    .InterceptedBy(typeof(LogMethodCallInterceptor)) // Enable method call logging if needed.
    .InterceptedBy(typeof(LogMethodResultInterceptor)); // Enable result logging if needed.

```
```json
// appsettings.json 
{
  "Tracing": {
    "Enabled": true,
    "Jaeger": {
      "Enabled": true,
      "MaxPacketSize": 1234,
      "Sampler": "",
      "Udp": {
        "Enabled": true,
        "Host": "localhost",
        "Port": 6831
      }
    },
    "Masstransit": {
      "Enabled": true,
      "Endpoint": "http://localhost:4317",
      "Protocol": "HttpProtobuf"
    }
  },
  "Metrics": {
    "Enabled": true,
    "EnablePrometheus": true
  },
  "logger": {
    "level": "Information",
    "excludePaths": [ "/swagger", "_framework", "/_vs" ],
    "console": {
      "enabled": true
    },
    "file": {
      "enabled": true,
      "path": "logs/logs.txt",
      "interval": "day"
    },
    "seq": {
      "enabled": true,
      "url": "http://localhost:5341",
      "apiKey": ""
    }
  }
}
```

You can deactivate individual components by either setting `"Enabled": false` or by commenting out or removing sections like this one from the logger configuration:
```json
"file": {
  "enabled": true,
  "path": "logs/logs.txt",
  "interval": "day"
}
```
If you provide an incorrect value, such as an empty string, it will result in an InvalidOperationException being thrown.

# Mediator / CQRS
In contrast to other implementations of the Mediator pattern, our Mediator doesn't require the creation of a new class for each query or command. Instead, you can work with self-descriptive methods in one service class. This approach strikes a balance between design granularity (the number of classes) and code readability.
```csharp
    public interface IOrderCommandService
    {
        Task AwaitingValidationOrder(AwaitingValidationOrderCommand cmd);
        Task CancelOrder(CancelOrderCommand cmd);
        Task CreateOrder(CreateOrderCommand cmd);
        Task CreateOrder(CreateOrderDraftCommand cmd);
    }
```

### Creating commands and queries

You can create commands and queries like the examples below:
```csharp
public class CancelOrderCommand : ICommand
{
    public CancelOrderCommand(Guid Orderid)
    {
        this.OrderId = Orderid;
    }

    public Guid OrderId { get; }
}
```
```csharp
public class GetOrderQuery : IQuery<OrderResource>
{
    public Guid Id { get; }

    public GetOrderQuery(Guid id)
    {
        Id = id;
    }
}
```
### Adding validation with FluentValidations

If necessary, you can add validation using FluentValidations to a command or query, as demonstrated here:
```csharp
public class CancelOrderValidation : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderValidation()
    {
        RuleFor(x => x.OrderId).NotNull();
    }
}
```

### Using commands and queries in service methods

You have the flexibility to utilize these commands or queries within any of your public service methods.
```csharp
public async Task CancelOrder(CancelOrderCommand cmd)
{
    OrderException.ThrowIfNull(cmd);

    var order = await orderRepository.GetAsync(cmd.OrderId);
    order.Cancel();

    await orderRepository.SaveAsync(order);
}
```
Commands and queries are designed to be used exclusively within a single method.

### Add routing straight to services
You can easily incorporate HTTP routing into services that utilize Mediator by using extension methods from `MicroFusion.Mediator.EndpointsExtensions`. For instance, simply including `app.MapDelete<CancelOrderCommand>("Order")` means that when you access the `/order` endpoint with the HTTP delete method and the `CancelOrderCommand`, Mediator will automatically execute the corresponding method in the appropriate service. 

When FluentValidations are applied to commands or queries, validation is automatically performed. Users will receive the appropriate validation messages and corresponding HTTP status codes.

```csharp
app.MapPost<CreateOrderCommand>("Order")
app.MapDelete<CancelOrderCommand>("Order")
app.MapPost<AwaitingValidationOrderCommand>("Order/AwaitingValidation")
app.MapPost<CreateOrderDraftCommand>("Order/Draf")
app.MapGet<GetOrderQuery, OrderResource>("Order")
```
