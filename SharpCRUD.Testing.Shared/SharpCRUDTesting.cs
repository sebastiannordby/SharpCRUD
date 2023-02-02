using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.DataAccess;
using SharpCRUD.Domain;
using System;

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

            return services.BuildServiceProvider();
        }
    }
}