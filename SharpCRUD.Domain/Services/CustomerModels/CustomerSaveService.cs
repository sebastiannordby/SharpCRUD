using SharpCRUD.Domain;
using SharpCRUD.Domain.Models.CustomerModels;
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
        private readonly IAssembleService<CustomerAssembleResult, CustomerDto> _assembleCustomerService;
        private readonly IValidateService<CustomerAssembleResult, CustomerValidationResult> _validateCustomerService;
        private readonly SharpCrudContext _dbContext;

        public CustomerSaveService(
            IAssembleService<CustomerAssembleResult, CustomerDto> assembleCustomerService,
            IValidateService<CustomerAssembleResult, CustomerValidationResult> validateCustomerService,
            SharpCrudContext dbContext)
        {
            _assembleCustomerService = assembleCustomerService;
            _validateCustomerService = validateCustomerService;
            _dbContext = dbContext;
        }

        public async Task<Guid> Save(CustomerDto model)
        {
            if (model == null) 
                throw new ArgumentNullException("Model cannot be null.");

            var assembleResult = await _assembleCustomerService
                .Assemble(model);
          
            var validationResult = await _validateCustomerService
                .Validate(assembleResult);
            if (!validationResult.IsSuccessful)
                throw new SharpCRUDValidationException(validationResult);

            if (assembleResult.Customer.IsNew)
                await _dbContext.Customers.AddAsync(assembleResult.Customer.Model);
            else
                _dbContext.Customers.Update(assembleResult.Customer.Model);

            foreach(var address in assembleResult.Addresses)
            {
                if (address.IsNew)
                    await _dbContext.CustomerAddresses.AddAsync(address.Model);
                else
                    _dbContext.CustomerAddresses.Update(address.Model);
            }

            await _dbContext.SaveChangesAsync();

            return assembleResult.Customer.Model.Id;
        }
    }
}
