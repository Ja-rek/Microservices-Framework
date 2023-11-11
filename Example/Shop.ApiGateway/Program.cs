using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using MicroFusion;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMicroFusion(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddOcelot();

builder.Configuration
    .AddJsonFile("ocelot.json");


builder.UseMicroFusion();

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
