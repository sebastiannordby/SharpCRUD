using SharpCRUD.API.Models;
using SharpCRUD.API.Repositories.CustomerModels;
using SharpCRUD.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API.Implementation.Services.Customer
{
    internal class EditCustomerService : IEditCustomerService
    {
        private readonly ICustomerCompositeRepository _compositeRepository;

        public EditCustomerService(
            ICustomerCompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository;
        }

        public Task<EditCustomer> Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EditCustomer> Initialize()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Save(EditCustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}
