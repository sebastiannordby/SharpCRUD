using MediatR;
using SharpCRUD.Domain.UseCases.Shared;
using SharpCRUD.Library.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.UseCases.CustomerUC.Queries.FindComposite
{
    public sealed record FindCompositeCustomerQuery(Guid CustomerId) : IQuery<CustomerCompositeDto>;
}
