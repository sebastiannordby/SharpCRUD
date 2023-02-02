using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.Services.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services
{
    internal static class DomainServicesInstaller
    {
        internal static IServiceCollection AddDomainLayerServices(this IServiceCollection services)
        {
            return services
                .AddCustomerModelsServices();
        }
    }
}
