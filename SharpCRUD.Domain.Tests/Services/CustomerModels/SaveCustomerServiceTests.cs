using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.Exceptions;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using SharpCRUD.Shared.Models.CustomerModels;
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

        [Test]
        public async Task FindCompositeCustomer()
        {
            var customerService = _serviceProvider.GetService<ISaveService<CustomerDto>>();
            var customerCompositeService = _serviceProvider.GetService<ICompositeService<CustomerCompositeDto>>();

            var customerId = await customerService.Save(new CustomerDto()
            {
                Number = 1,
                Name = nameof(FindCompositeCustomer)
            });

            var customerComposite = await customerCompositeService.Find(customerId);

            Assert.IsNotNull(customerComposite);
        }

        [Test]
        public async Task SaveCompositeCustomer()
        {
            var customerService = _serviceProvider.GetService<ISaveService<CustomerDto>>();
            var customerCompositeService = _serviceProvider.GetService<ICompositeService<CustomerCompositeDto>>();

            var customerId = await customerService.Save(new CustomerDto()
            {
                Number = 1,
                Name = nameof(FindCompositeCustomer)
            });

            var customerComposite = await customerCompositeService.Find(customerId);
            var updatedName = "Updated name";

            customerComposite.Name = updatedName;

            var updatedCustomerId = await customerService.Save(customerComposite.ToDto());

            Assert.IsNotNull(customerComposite);
            Assert.IsTrue(customerId == updatedCustomerId);
            Assert.IsTrue(nameof(FindCompositeCustomer) != updatedName);
        }
    }
}
