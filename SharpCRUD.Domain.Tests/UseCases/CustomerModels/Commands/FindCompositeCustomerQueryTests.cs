using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.UseCases.CustomerUC.Commands.FindComposite;
using SharpCRUD.Domain.UseCases.CustomerUC.Commands.Save;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Tests.UseCases.CustomerModels.Commands
{
    public sealed class FindCompositeCustomerQueryTests : DomainBaseTest
    {
        [Test]
        public async Task ReachesQuery()
        {
            var mediator = _serviceProvider.GetService<IMediator>();
            var customerDto = new CustomerDto(
                id: null,
                number: 0,
                name: nameof(ReachesQuery),
                organizationNumber: "12332332",
                phoneNumber: "112",
                addresses: new());
            var customerId = await mediator.Send(
                new SaveCustomerCommand(customerDto));

            var compositeCustomer = await mediator.Send(
                new FindCompositeCustomerQuery(customerId));

            Assert.IsNotNull(compositeCustomer);
        }
    }
}
