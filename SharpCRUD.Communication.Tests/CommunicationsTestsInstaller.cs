using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Communication.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Tests
{
    public class CommunicationsTestsInstaller
    {
        public static IServiceProvider GetTestServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSharpCRUDCommunication();
            services.AddSharpCRUDHttpRepositories<TestConfigurationService>();

            return services.BuildServiceProvider();
        }
    }
}
