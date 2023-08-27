using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Infrastructure
{
    public static class InfrastructureLayerInstaller
    {
        public static IServiceCollection AddInfrastructureLayer(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> ContextDelegate)
        {
            return services.AddDbContextFactory<SharpCrudContext>(ContextDelegate);
        }
    }
}
