using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Communication.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication
{
    public static class SharpCRUDAPIInstaller
    {
        public static IServiceCollection AddSharpCRUDCommunication(this IServiceCollection services)
        {
            return services
                .AddServices();
        }
    }
}
