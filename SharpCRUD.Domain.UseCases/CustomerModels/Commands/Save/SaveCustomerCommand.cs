using MediatR;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.UseCases.CustomerModels.Commands.Save
{
    public sealed record SaveCustomerCommand(CustomerDto Customer) : IRequest<Guid>;
}
