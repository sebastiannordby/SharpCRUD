using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.Validation.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class ValidateCustomerService : IValidateService<Customer, CustomerValidationResult>
    {
        public Task<CustomerValidationResult> Validate(Customer entity)
        {
            return Task.FromResult(new CustomerValidationResult()
            {
                IsSuccessful = false
            });
        }
    }
}
