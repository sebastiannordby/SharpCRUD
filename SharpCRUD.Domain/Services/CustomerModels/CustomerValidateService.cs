using FluentValidation.Results;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.Validation.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class CustomerValidateService : IValidateService<CustomerAssembleResult, CustomerValidationResult>
    {
        public async Task<CustomerValidationResult> Validate(CustomerAssembleResult assembleRes)
        {
            var validationFailures = new List<ValidationFailure>();
            var customer = assembleRes.Customer;
            var addresses = assembleRes.Addresses;

            if (string.IsNullOrWhiteSpace(customer.Name))
                validationFailures.Add(new(
                    nameof(customer.Name), "Name is required."));

            foreach(var address in addresses ?? new List<CustomerAddress>())
            {
                if(address.CustomerId != customer.Id)
                    validationFailures.Add(new(
                        nameof(address.CustomerId), $"Address({address.Id}) not connected to Customer."));

                if (string.IsNullOrWhiteSpace(address.AddressLine1))
                    validationFailures.Add(new(
                        nameof(address.AddressLine1), "AddressLine1 is required."));
            }

            return await Task.FromResult(
                new CustomerValidationResult(validationFailures));
        }
    }
}
