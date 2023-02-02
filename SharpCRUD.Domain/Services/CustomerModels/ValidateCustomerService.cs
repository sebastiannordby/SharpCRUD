using FluentValidation.Results;
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
            var validationFailures = new List<ValidationFailure>();

            if (string.IsNullOrWhiteSpace(entity.Name))
                validationFailures.Add(new ValidationFailure(nameof(entity.Name), "Name is required."));

            return Task.FromResult(new CustomerValidationResult()
            {
                IsSuccessful = !validationFailures.Any()
            });
        }
    }
}
