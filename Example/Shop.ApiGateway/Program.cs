using MicroservicesFramework.Auth;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuth()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddOcelot();

builder.Configuration
    .AddJsonFile("ocelot.json");


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

app.UseOcelot().Wait();

app.Run();
