using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Communication.Http.Repositories.Customer;
using SharpCRUD.Communication.Http.Tools;
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
        public static IServiceCollection AddSharpCRUDHttpRepositories<TConfigurationService>(this IServiceCollection services)
            where TConfigurationService : class, ISharpCRUDConfigurationService
        {
            return services
                .AddScoped<ICustomerCompositeRepository, HttpCustomerCompositeRepository>()
                .AddScoped<ICustomerRepository, HttpCustomerRepository>()
                .AddScoped<ISharpCRUDConfigurationService, TConfigurationService>()
                .AddScoped<ISharpCRUDHttpClientService, SharpCRUDHttpClientService>()
                .AddScoped<ISharpCRUDHttpClientTask, SharpCRUDHttpClientTask>();
        }
    }
}
