using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain;
using System;
using SharpCRUD.Domain.UseCases;
using Microsoft.EntityFrameworkCore;
using SharpCRUD.Infrastructure;

namespace SharpCRUD.Testing.Shared
{
    public static class SharpCRUDTesting
    {
        public static IServiceProvider GetTestServiceProvider()
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddUserSecrets(typeof(SharpCRUDTesting).Assembly)
            //    .AddEnvironmentVariables();

            var services = new ServiceCollection();

            services.AddInfrastructureLayer(options =>
            {
                options.UseInMemoryDatabase(nameof(SharpCRUDTesting), b => {
                    b.EnableNullChecks(false);
                });
            });
            services.AddDomainLayer();
            services.AddDomainUseCases();

            return services.BuildServiceProvider();
        }
    }
}