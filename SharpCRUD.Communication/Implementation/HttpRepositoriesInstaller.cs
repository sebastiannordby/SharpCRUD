using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Communication.Implementation.Repositories.Customer;
using SharpCRUD.Communication.Repositories.Customer;
using SharpCRUD.Communication.Repositories.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Implementation
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
