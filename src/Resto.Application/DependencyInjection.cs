using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Resto.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            
            
            // Register MediatR and pipeline behaviors
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
              //  cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
              //  cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            // Register FluentValidation validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
