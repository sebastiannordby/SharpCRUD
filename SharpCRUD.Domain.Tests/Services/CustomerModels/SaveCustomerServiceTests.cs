using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.Exceptions;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Tests.Services.CustomerModels
{
    public class SaveCustomerServiceTests : DomainBaseTest
    {
        [Test]
        public void CustomerServiceIsAvailable()
        {
            Assert.IsNotNull(
                _serviceProvider.GetService<ISaveService<CustomerDto>>());
        }

        [Test]
        public async Task SaveNullThrowsError()
        {
            var customerService = _serviceProvider.GetService<ISaveService<CustomerDto>>();

            Assert.ThrowsAsync<ArgumentNullException>(async() =>
            {
                await customerService.Save(null);
            });
        }

        [Test]
        public async Task SaveShouldThrowValidationException()
        {
            var customerService = _serviceProvider.GetService<ISaveService<CustomerDto>>();

            Assert.ThrowsAsync<SharpCRUDValidationException>(async () =>
            {
                await customerService.Save(new CustomerDto()
                {

                });
            });
        }
    }
}
