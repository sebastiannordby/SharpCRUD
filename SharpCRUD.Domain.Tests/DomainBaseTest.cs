using SharpCRUD.Testing.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Tests
{
    public class DomainBaseTest
    {
        protected IServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void OneTimeSetUp() 
        {
            _serviceProvider = SharpCRUDTesting.GetTestServiceProvider();
        }
    }
}
