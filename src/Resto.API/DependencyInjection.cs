using Resto.Application.Common.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
namespace Resto.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddExceptionHandler<CustomExceptionHandler>();


        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database")!);

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {

        app.UseExceptionHandler(options => { });


        app.UseHealthChecks("/health",
           new HealthCheckOptions
           {
               ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
           });
        return app;
    }
}
