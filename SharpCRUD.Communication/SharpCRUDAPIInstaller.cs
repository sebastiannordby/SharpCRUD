using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Communication.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API
{
    public static class SharpCRUDAPIInstaller
    {
        public static IServiceCollection AddSharpCRUDApi(this IServiceCollection services)
        {
            return services
                .AddHttpRepositories()
                .AddServices();
        }
    }
}
