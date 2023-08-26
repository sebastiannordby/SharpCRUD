﻿using SharpCRUD.Domain;
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
        private readonly ISaveEntity<Customer> _saveCustomerEntityService;
        private readonly SharpCrudContext _dbContext;

        public CustomerSaveService(
            IAssembleService<CustomerAssembleResult, CustomerDto> assembleCustomerService,
            IValidateService<CustomerAssembleResult, CustomerValidationResult> validateCustomerService,
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

            var assembleResult = await _assembleCustomerService
                .Assemble(model);
          
            var customerValidationResult = await _validateCustomerService
                .Validate(assembleResult);
            if (!customerValidationResult.IsSuccessful)
                throw new SharpCRUDValidationException(customerValidationResult);

            await _saveCustomerEntityService.Save(assembleResult.Customer);

            return assembleResult.Customer.Id.Value;
        }
    }
}
