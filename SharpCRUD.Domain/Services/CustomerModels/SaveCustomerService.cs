using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class SaveCustomerService : ISaveService<CustomerDto>
    {
        private readonly IAssembleService<Customer, CustomerDto> _assembleCustomerService;

        public SaveCustomerService(IAssembleService<Customer, CustomerDto> assembleCustomerService)
        {
            _assembleCustomerService = assembleCustomerService;
        }

        public Task<Guid> Save(CustomerDto model)
        {
            if (model == null) 
                throw new ArgumentNullException("Model cannot be null.");

            return Task.FromResult(Guid.Empty);
        }
    }
}
