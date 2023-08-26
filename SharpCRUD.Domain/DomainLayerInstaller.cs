using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain;
using SharpCRUD.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace SharpCRUD.Domain
{
    public static class DomainLayerInstaller
    {
        public static IServiceCollection AddDomainLayer(this IServiceCollection services)
        {
            return services
                .AddDomainLayerServices();
        }

        public static IServiceCollection AddDataAccessLayer(
            this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContextFactory<SharpCrudContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
            });

            return services;
        }

        public static IServiceCollection AddTestDataAccessLayer(
            this IServiceCollection services, string testDatabaseName)
        {
            services.AddDbContextFactory<SharpCrudContext>(options =>
            {
                options.UseInMemoryDatabase(testDatabaseName, b => {

                    b.EnableNullChecks(false);
                });
            });

            return services;
        }
    }
}
