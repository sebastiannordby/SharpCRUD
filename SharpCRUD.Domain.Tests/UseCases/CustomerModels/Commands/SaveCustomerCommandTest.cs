using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharpCRUD.Domain.UseCases.CustomerModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Tests.UseCases.CustomerModels.Commands
{
    public class SaveCustomerCommandTest : DomainBaseTest
    {
        [Test]
        public async Task ReachesCommand()
        {
            var mediator = _serviceProvider.GetService<IMediator>();

            Assert.IsNotNull(mediator, "Mediator service not available");
            Assert.ThrowsAsync<NotImplementedException>(async () =>
            {
                var result = await mediator.Send(new SaveCustomerCommand()
                {

                });
            });
        }
    }
}
