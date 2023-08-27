using SharpCRUD.Communication.Models;
using SharpCRUD.Communication.Repositories.CustomerModels;
using SharpCRUD.Communication.Services;
using SharpCRUD.Library.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Implementation.Services.Customer
{
    internal class EditCustomerService : IEditCustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ICustomerCompositeRepository _compositeRepository;

        public EditCustomerService(
            ICustomerRepository repository,
            ICustomerCompositeRepository compositeRepository)
        {
            _repository = repository;
            _compositeRepository = compositeRepository;
        }

        public Task<EditCustomer> Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<EditCustomer> Initialize()
        {
            return await Task.FromResult(
                new EditCustomer(new CustomerCompositeDto(), true));
        }

        public async Task<Guid> Save(EditCustomer customer)
        {
            return await _repository.Save(customer.Compose());
        }
    }
}
