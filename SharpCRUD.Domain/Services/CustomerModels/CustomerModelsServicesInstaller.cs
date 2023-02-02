using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using SharpCRUD.Shared.Models.CustomerModels;
using SharpCRUD.Shared.Validation.CustomerModels;
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
            services.AddScoped<ISaveService<CustomerDto>, CustomerSaveService>();
            services.AddScoped<IAssembleService<CustomerAssembleResult, CustomerDto>, CustomerAssembleService>();
            services.AddScoped<IValidateService<Customer, CustomerValidationResult>, CustomerValidateService>();
            services.AddScoped<ICompositeService<CustomerCompositeDto>, CustomerCompositeService>();
            services.AddScoped<ISaveEntity<Customer>, GenericSaveEntityService<Customer>>();

            return services;
        }
    }
}
