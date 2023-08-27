using Microsoft.EntityFrameworkCore;
using SharpCRUD.Domain;
using SharpCRUD.Domain.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class CustomerCompositeService : ICompositeService<CustomerCompositeDto>
    {
        private readonly SharpCrudContext _dbContext;

        public CustomerCompositeService(
            SharpCrudContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerCompositeDto> Find(Guid customerId)
        {
            var customerQuery = _dbContext.Customers
                .AsNoTracking()
                .Where(x => x.Id == customerId);
            if (!customerQuery.Any())
                throw new ArgumentException($"No Customer with given id({customerId})");

            return await (
                from customer in customerQuery
                let addresses = (
                    from address in _dbContext.CustomerAddresses
                        .AsNoTracking()
                        .Where(x => x.CustomerId == customer.Id)

                    select new CustomerCompositeDto.Address(
                        address.Id,
                        address.AddressLine1,
                        address.AddressLine2,
                        address.AddressLine3,
                        address.PostalCode,
                        address.PostalLocality)
                ).ToList()

                select new CustomerCompositeDto(
                    customer.Id,
                    customer.Number,
                    customer.Name,
                    customer.OrganizationNumber,
                    customer.PhoneNumber,
                    addresses)
            ).FirstOrDefaultAsync();
        }
    }
}
