using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharpCRUD.Domain.UseCases.CustomerUC.Commands.Save;
using SharpCRUD.Shared.CustomerModels;

namespace SharpCRUD.RestAPI.Controllers
{
    public class CustomerController : SharpCRUDController
    {
        public CustomerController(
            IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("Save")]
        public async Task<Guid> Save(
            [FromBody] CustomerDto customer)
        {
            return await ExecuteCommand(new SaveCustomerCommand(customer));
        }
    }
}