using MediatR;

namespace SharpCRUD.Domain.UseCases.Shared
{
    public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    { 

    }
}
