using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SharpCRUD.DataAccess
{
    public static class DataAccessLayerInstaller
    {
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
                options.UseInMemoryDatabase(testDatabaseName);
            });

            return services;
        }
    }
}
