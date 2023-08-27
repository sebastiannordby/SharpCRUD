using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.UseCases.CustomerModels.Commands.Save;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Tests.UseCases.CustomerModels.Commands
{
    public class SaveCustomerCommandTests : DomainBaseTest
    {
        [Test]
        public async Task ReachesCommand()
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            Assert.IsNotNull(mediator, "Mediator service not available");
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await mediator.Send(new SaveCustomerCommand(null));
            });
        }

        [Test]
        public async Task SaveCustomerTest()
        {
            var mediator = _serviceProvider.GetService<IMediator>();
            var customerDto = new CustomerDto(
                id: null,
                number: 0,
                name: nameof(SaveCustomerTest),
                organizationNumber: "12332332",
                phoneNumber: "112",
                addresses: new());
            var customerId = await mediator.Send(
                new SaveCustomerCommand(customerDto));

            Assert.IsTrue(customerId != Guid.Empty);
        }
    }
}
