using MediatR;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.UseCases.CustomerUC.Commands.FindComposite
{
    public sealed class FindCompositeCustomerQueryHandler : IRequestHandler<FindCompositeCustomerQuery, CustomerCompositeDto>
    {
        private readonly ICompositeService<CustomerCompositeDto> _compositeService;

        public FindCompositeCustomerQueryHandler(
            ICompositeService<CustomerCompositeDto> compositeService)
        {
            _compositeService = compositeService;
        }

        public async Task<CustomerCompositeDto> Handle(FindCompositeCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _compositeService.Find(request.CustomerId);
        }
    }
}
