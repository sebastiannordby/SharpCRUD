using FluentValidation.Results;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Library.Validation.CustomerModels;
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

            if (string.IsNullOrWhiteSpace(customer.Model.Name))
                validationFailures.Add(new(
                    nameof(customer.Model.Name), "Name is required."));

            foreach(var address in addresses ?? new())
            {
                if(address.Model.CustomerId != customer.Model.Id)
                    validationFailures.Add(new(
                        nameof(address.Model.CustomerId), $"Address({address.Model.Id}) not connected to Customer."));

                if (string.IsNullOrWhiteSpace(address.Model.AddressLine1))
                    validationFailures.Add(new(
                        nameof(address.Model.AddressLine1), "AddressLine1 is required."));
            }

            return await Task.FromResult(
                new CustomerValidationResult(validationFailures));
        }
    }
}
