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

        public Task<CustomerCompositeDto> Find(Guid id)
        {
            var customerId = new CustomerId(id);
            var customer = _dbContext.Customers
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == customerId);
            if (customer == null)
                throw new ArgumentException($"No Customer with given id({id})");

            return Task.FromResult(new CustomerCompositeDto()
            {
                Id = customer.Id.Value,
                Number = customer.Number,
                Name = customer.Name
            });
        }
    }
}
