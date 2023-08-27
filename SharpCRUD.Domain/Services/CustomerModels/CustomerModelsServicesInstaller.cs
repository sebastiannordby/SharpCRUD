using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Library.CustomerModels;
using SharpCRUD.Library.Models.CustomerModels;
using SharpCRUD.Library.Validation.CustomerModels;
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

            return services;
        }
    }
}
