using SharpCRUD.Domain;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Extensions;
using SharpCRUD.Domain.Services.CustomerModels.Address;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using SharpCRUD.Shared.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly CustomerNumberService _customerNumberService;
        private readonly IAssembleService<CustomerAddressAssembleResult, CustomerAddressDto> _addressAssembler;

        public CustomerAssembleService(
            SharpCrudContext dbContext, 
            CustomerNumberService customerNumberService,
            IAssembleService<CustomerAddressAssembleResult, CustomerAddressDto> addressAssembler)
        {
            _dbContext = dbContext;
            _customerNumberService = customerNumberService;
            _addressAssembler = addressAssembler;
        }

        public async Task<CustomerAssembleResult> Assemble(CustomerDto dto)
        {
            var processedCustomer = _dbContext.Customers
                .FirstOrDefault(x => x.Id.Value == dto.Id);
            var isNew = processedCustomer == null;
            var processedAddresses = new List<EntityAssembleResult<CustomerAddress>>();

            if(processedCustomer != null)
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

                processedCustomer = new Customer(
                    id: new CustomerId(dto.Id),
                    number: number,
                    name: dto.Name,
                    organizationNumber: dto.OrganizationNumber,
                    phoneNumber: dto.PhoneNumber
                );
            }

            foreach(var address in dto.Addresses ?? new List<CustomerAddressDto>())
            {
                address.CustomerId = processedCustomer.Id.Value;
                var addressAssembleResult = await _addressAssembler.Assemble(address);
                processedAddresses.Add(addressAssembleResult.Address);
            }

            return new CustomerAssembleResult(
                customer: new(processedCustomer, isNew),
                addresses: processedAddresses);
        }
    }
}
