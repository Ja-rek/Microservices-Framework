using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using MicroservicesFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMicroservicesFramework()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddOcelot();

builder.Configuration
    .AddJsonFile("ocelot.json");


builder.UseMicroservicesFramework();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

await app.UseOcelot();

app.Run();
