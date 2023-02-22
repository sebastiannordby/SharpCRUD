using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.UseCases.Behaviours;

namespace SharpCRUD.Domain.UseCases
{
    public static class DomainUseCasesInstaller
    {
        public static IServiceCollection AddDomainUseCases(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            return services;
        }
    }
}