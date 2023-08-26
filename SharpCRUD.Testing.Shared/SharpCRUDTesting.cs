using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain;
using SharpCRUD.Domain;
using System;
using SharpCRUD.Domain.UseCases;

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

            services.AddTestDataAccessLayer(nameof(SharpCRUDTesting));
            services.AddDomainLayer();
            services.AddDomainUseCases();

            return services.BuildServiceProvider();
        }
    }
}