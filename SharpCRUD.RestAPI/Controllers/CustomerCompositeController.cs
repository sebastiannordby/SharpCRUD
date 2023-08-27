using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharpCRUD.Domain.UseCases.CustomerUC.Queries.FindComposite;
using SharpCRUD.Library.Models.CustomerModels;

namespace SharpCRUD.RestAPI.Controllers
{
    public class CustomerCompositeController : SharpCRUDController
    {
        public CustomerCompositeController(
            IMediator mediator) : base(mediator)
        {

        }

        [HttpGet("Find/Id/{Id}")]
        public async Task<CustomerCompositeDto> Find(
            [FromRoute] Guid id, CancellationToken cancellationToken)
        {
            return await ExecuteQuery(new FindCompositeCustomerQuery(id));
        } 
    }
}
