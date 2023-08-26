using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Services.CustomerModels.Address;
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
            // Customer
            services.AddScoped<ISaveService<CustomerDto>, CustomerSaveService>();
            services.AddScoped<IAssembleService<CustomerAssembleResult, CustomerDto>, CustomerAssembleService>();
            services.AddScoped<IValidateService<CustomerAssembleResult, CustomerValidationResult>, CustomerValidateService>();
            services.AddScoped<ICompositeService<CustomerCompositeDto>, CustomerCompositeService>();
            services.AddScoped<IEntityNumberService<Customer>, CustomerNumberService>();

            // CustomerAddress
            services.AddScoped<IAssembleService<CustomerAddressAssembleResult, CustomerAddressDto>, CustomerAddressAssembleService>();

            return services;
        }
    }
}
