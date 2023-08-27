using MediatR;

namespace SharpCRUD.Domain.UseCases.Shared
{
    public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {

    }
}
