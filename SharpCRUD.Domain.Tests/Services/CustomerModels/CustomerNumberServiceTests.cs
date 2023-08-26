using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Tests.Services.CustomerModels
{
    public class CustomerNumberServiceTests : DomainBaseTest
    {
        [Test]
        public void CustomerServiceIsAvailable()
        {
            Assert.IsNotNull(
                _serviceProvider.GetService<IEntityNumberService<Customer>>());
        }

        [Test]
        public async Task CreatesNumberHigherThanZero()
        {
            var service = _serviceProvider.GetService<IEntityNumberService<Customer>>();
            var newNumber = await service.GetRequestedOrNewNumber();

            Assert.IsTrue(newNumber >= 0);
        }
    }
}
