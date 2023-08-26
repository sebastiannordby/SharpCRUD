using SharpCRUD.Domain;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels.Address
{
    internal class CustomerAddressAssembleResult : AssembleResult
    {
        internal EntityAssembleResult<CustomerAddress> Address { get; private set; }

        internal CustomerAddressAssembleResult(
            EntityAssembleResult<CustomerAddress> address)
        {
            Address = address;
        }
    }

    internal class CustomerAddressAssembleService : IAssembleService<CustomerAddressAssembleResult, CustomerAddressDto>
    {
        private readonly SharpCrudContext _dbContext;

        public CustomerAddressAssembleService(SharpCrudContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<CustomerAddressAssembleResult> Assemble(
            CustomerAddressDto dto)
        {
            var processedEntity = _dbContext.CustomerAddresses
                .FirstOrDefault(x => x.Id.Value == dto.Id);
            var isNew = processedEntity == null;

            if (processedEntity != null) 
            {
                processedEntity.Update(
                    addressLine1: dto.AddressLine1,
                    addressLine2: dto.AddressLine2,
                    addressLine3: dto.AddressLine3,
                    postalCode: dto.PostalCode,
                    postalLocality: dto.PostalLocality
                );
            }
            else
            {
                processedEntity = new CustomerAddress(
                    id: new CustomerAddressId(dto.Id),
                    customerId: new CustomerId(dto.CustomerId),
                    addressLine1: dto.AddressLine1,
                    addressLine2: dto.AddressLine2,
                    addressLine3: dto.AddressLine3,
                    postalCode: dto.PostalCode,
                    postalLocality: dto.PostalLocality
                );
            }

            return Task.FromResult(new CustomerAddressAssembleResult(
                address: new(processedEntity, isNew)));
        }
    }
}
