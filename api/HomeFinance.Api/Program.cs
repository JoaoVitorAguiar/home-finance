using System.Reflection;
using HomeFinance.Api.Endpoints;
using HomeFinance.Api.Middlewares;
using HomeFinance.Infra.DependencyInjection;
using Scalar.AspNetCore;
using Wolverine;
using Wolverine.FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services
    .AddExceptionHandler<ValidationExceptionHandler>()
    .AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Host.UseWolverine(opts =>
{
    var appAssembly = Assembly.Load("HomeFinance.Application");
    opts.Discovery.IncludeAssembly(appAssembly);
    opts.UseFluentValidation();
});

builder.Services.AddInfraModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/api-docs");
}
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapPersonEndpoints();

app.Run();
