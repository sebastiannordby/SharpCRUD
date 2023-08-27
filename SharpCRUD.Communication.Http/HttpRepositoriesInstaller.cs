using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Communication.Http.Repositories.Customer;
using SharpCRUD.Communication.Repositories.Customer;
using SharpCRUD.Communication.Repositories.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Http
{
    public static class HttpRepositoriesInstaller
    {
        public static IServiceCollection AddSharpCRUDHttpRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICustomerCompositeRepository, HttpCustomerCompositeRepository>()
                .AddScoped<ICustomerRepository, HttpCustomerRepository>();
        }
    }
}
