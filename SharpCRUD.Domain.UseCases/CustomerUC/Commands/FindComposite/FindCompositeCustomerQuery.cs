using MediatR;
using SharpCRUD.Shared.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.UseCases.CustomerUC.Commands.FindComposite
{
    public sealed record FindCompositeCustomerQuery(Guid CustomerId) : IRequest<CustomerCompositeDto>;
}
