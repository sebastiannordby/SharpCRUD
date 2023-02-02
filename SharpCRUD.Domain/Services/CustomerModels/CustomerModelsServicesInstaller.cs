using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal static class CustomerModelsServicesInstaller
    {
        internal static IServiceCollection AddCustomerModelsServices(this IServiceCollection services)
        {
            services.AddScoped<ISaveService<CustomerDto>, SaveCustomerService>();
            services.AddScoped<IAssembleService<Customer, CustomerDto>, AssembleCustomerService>();

            return services;
        }
    }
}
