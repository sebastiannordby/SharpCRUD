using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharpCRUD.Domain.UseCases.Shared;

namespace SharpCRUD.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class SharpCRUDController
    {
        protected IMediator _mediator;

        protected SharpCRUDController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Executed queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<T> ExecuteQuery<T>(
            IQuery<T> request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }

        /// <summary>
        /// Executes commands.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected async Task<T> ExecuteCommand<T>(
            ICommand<T> request, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
