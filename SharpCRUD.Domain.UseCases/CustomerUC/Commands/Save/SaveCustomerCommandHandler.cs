using MediatR;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Domain.UseCases.Shared;
using SharpCRUD.Library.CustomerModels;

namespace SharpCRUD.Domain.UseCases.CustomerUC.Commands.Save
{
    public class SaveCustomerCommandHandler : ICommandHandler<SaveCustomerCommand, Guid>
    {
        private readonly ISaveService<CustomerDto> _service;

        public SaveCustomerCommandHandler(
            ISaveService<CustomerDto> service)
        {
            _service = service;
        }

        public async Task<Guid> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request.Customer == null)
                throw new ArgumentNullException("Customer cannot be null.");

            return await _service.Save(request.Customer);
        }
    }
}
