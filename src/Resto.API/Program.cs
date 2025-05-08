using Microsoft.AspNetCore.Builder;
using Resto.API;
using Resto.Application;
using Resto.Infrastructure;
using Resto.Infrastructure.Data.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.MapOpenApi();

// Configure the HTTP request pipeline.

app.UseApiServices();

if (app.Environment.IsDevelopment()) {
   //await app.InitialiseDatabaseAsync();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
