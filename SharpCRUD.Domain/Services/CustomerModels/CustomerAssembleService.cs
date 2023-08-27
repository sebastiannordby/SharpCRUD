using SharpCRUD.Domain;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Extensions;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using SharpCRUD.Shared.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class CustomerAssembleResult : AssembleResult
    {
        internal EntityAssembleResult<Customer> Customer { get; set; }
        internal List<EntityAssembleResult<CustomerAddress>> Addresses { get; set; }

        internal CustomerAssembleResult(EntityAssembleResult<Customer> customer, List<EntityAssembleResult<CustomerAddress>> addresses)
        {
            Customer = customer;
            Addresses = addresses;
        }
    }

    internal class CustomerAssembleService : IAssembleService<CustomerAssembleResult, CustomerDto>
    {
        private readonly SharpCrudContext _dbContext;
        private readonly IEntityNumberService<Customer> _customerNumberService;

        public CustomerAssembleService(
            SharpCrudContext dbContext, 
            IEntityNumberService<Customer> customerNumberService)
        {
            _dbContext = dbContext;
            _customerNumberService = customerNumberService;
        }

        public async Task<CustomerAssembleResult> Assemble(CustomerDto dto)
        {
            var (processedCustomer, isNewCustomer) = await ProcessCustomer(dto);
            var processedAddresses = await ProcessAddresses(dto, processedCustomer, isNewCustomer);

            return new CustomerAssembleResult(
                customer: new(processedCustomer, isNewCustomer),
                addresses: processedAddresses);
        }

        private async Task<(Customer processedCustomer, bool isNewCustomer)> ProcessCustomer(
            CustomerDto dto)
        {
            var processedCustomer = _dbContext.Customers
                .FirstOrDefault(x => x.Id == dto.Id);
            var isNewCustomer = processedCustomer == null;


            if (processedCustomer != null)
            {
                processedCustomer.Update(
                    name: dto.Name,
                    organizationNumber: dto.OrganizationNumber,
                    phoneNumber: dto.PhoneNumber);
            }
            else
            {
                var number = await _customerNumberService
                    .GetRequestedOrNewNumber(dto.Number);

                processedCustomer = new(
                    id: dto.Id ?? Guid.NewGuid(),
                    number: number,
                    name: dto.Name,
                    organizationNumber: dto.OrganizationNumber,
                    phoneNumber: dto.PhoneNumber);
            }

            return (processedCustomer, isNewCustomer);
        }

        private async Task<List<EntityAssembleResult<CustomerAddress>>> ProcessAddresses(
            CustomerDto dto, Customer processedCustomer, bool isNewCustomer)
        {
            var processedAddresses = new List<EntityAssembleResult<CustomerAddress>>();

            foreach (var address in dto.Addresses ?? new())
            {
                var processedAddress = !isNewCustomer && address.Id.HasValue ?
                    await _dbContext.CustomerAddresses
                        .FirstOrDefaultAsync(x => x.Id == address.Id.Value) : null;
                var isNewAddress = processedAddress == null;

                if (processedAddress != null)
                {
                    processedAddress.Update(
                        addressLine1: address.AddressLine1,
                        addressLine2: address.AddressLine2,
                        addressLine3: address.AddressLine3,
                        postalCode: address.PostalCode,
                        postalLocality: address.PostalLocality);
                }
                else
                {
                    processedAddress = new(
                        id: address.Id ?? Guid.NewGuid(),
                        customerId: processedCustomer.Id,
                        addressLine1: address.AddressLine1,
                        addressLine2: address.AddressLine2,
                        addressLine3: address.AddressLine3,
                        postalCode: address.PostalCode,
                        postalLocality: address.PostalLocality);
                }

                processedAddresses.Add(new(processedAddress, isNewAddress));
            }

            return processedAddresses;
        }
    }
}
