using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.API.Implementation.Services.Customer;
using SharpCRUD.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API.Implementation
{
    public static class ServicesInstaller
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IEditCustomerService, EditCustomerService>();
        }
    }
}
