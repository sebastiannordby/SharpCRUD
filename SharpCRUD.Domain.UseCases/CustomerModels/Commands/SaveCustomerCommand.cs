using MediatR;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.UseCases.CustomerModels.Commands
{
    public class SaveCustomerCommand : IRequest<Guid>
    {
        public CustomerDto Customer { get; set; }
    }

    public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, Guid>
    {
        public Task<Guid> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
