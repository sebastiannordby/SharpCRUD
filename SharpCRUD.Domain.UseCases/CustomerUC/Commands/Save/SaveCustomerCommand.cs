using MediatR;
using SharpCRUD.Domain.UseCases.Shared;
using SharpCRUD.Library.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.UseCases.CustomerUC.Commands.Save
{
    public sealed record SaveCustomerCommand(CustomerDto Customer) : ICommand<Guid>;
}
