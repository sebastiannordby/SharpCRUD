using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.API.Implementation.Repositories.Customer;
using SharpCRUD.API.Repositories.Customer;
using SharpCRUD.API.Repositories.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API.Implementation
{
    internal static class HttpRepositoriesInstaller
    {
        internal static IServiceCollection AddHttpRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerCompositeRepository, HttpCustomerCompositeRepository>()
                .AddScoped<ICustomerRepository, HttpCustomerRepository>();
        }
    }
}
