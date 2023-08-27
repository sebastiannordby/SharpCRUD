using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Communication.Implementation.Services.Customer;
using SharpCRUD.Communication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Implementation
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
