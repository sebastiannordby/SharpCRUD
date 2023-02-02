using SharpCRUD.DataAccess;
using SharpCRUD.DataAccess.Models.CustomerModels;
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
        public CustomerAddress Address { get; set; }
    }

    internal class CustomerAddressAssembleService : IAssembleService<CustomerAddressAssembleResult, CustomerAddressDto>
    {
        private readonly SharpCrudContext _dbContext;

        public CustomerAddressAssembleService(SharpCrudContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<CustomerAddressAssembleResult> Assemble(CustomerAddressDto dto)
        {
            var processedEntity = _dbContext.CustomerAddresses.Find(dto.Id);

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
                    id: dto.Id,
                    customerId: dto.CustomerId,
                    addressLine1: dto.AddressLine1,
                    addressLine2: dto.AddressLine2,
                    addressLine3: dto.AddressLine3,
                    postalCode: dto.PostalCode,
                    postalLocality: dto.PostalLocality
                );
            }

            return Task.FromResult(new CustomerAddressAssembleResult() 
            { 
                Address = processedEntity
            });
        }
    }
}
