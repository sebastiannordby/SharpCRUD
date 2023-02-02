using SharpCRUD.DataAccess;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Exceptions;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using SharpCRUD.Shared.Validation.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class CustomerSaveService : ISaveService<CustomerDto>
    {
        private readonly IAssembleService<Customer, CustomerDto> _assembleCustomerService;
        private readonly IValidateService<Customer, CustomerValidationResult> _validateCustomerService;
        private readonly ISaveEntity<Customer> _saveCustomerEntityService;
        private readonly SharpCrudContext _dbContext;

        public CustomerSaveService(
            IAssembleService<Customer, CustomerDto> assembleCustomerService,
            IValidateService<Customer, CustomerValidationResult> validateCustomerService,
            ISaveEntity<Customer> saveCustomerEntityService,
            SharpCrudContext dbContext)
        {
            _assembleCustomerService = assembleCustomerService;
            _validateCustomerService = validateCustomerService;
            _saveCustomerEntityService = saveCustomerEntityService;
            _dbContext = dbContext;
        }

        public async Task<Guid> Save(CustomerDto model)
        {
            if (model == null) 
                throw new ArgumentNullException("Model cannot be null.");

            var customer = await _assembleCustomerService.Assemble(model);
            var customerValidationResult = await _validateCustomerService.Validate(customer);

            if (!customerValidationResult.IsSuccessful)
                throw new SharpCRUDValidationException(customerValidationResult);

            await _saveCustomerEntityService.Save(customer);

            return customer.Id;
        }
    }
}
