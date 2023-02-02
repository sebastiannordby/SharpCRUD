﻿using SharpCRUD.DataAccess;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class CompositeCustomerService : ICompositeService<CustomerCompositeDto>
    {
        private readonly SharpCrudContext _dbContext;

        public CompositeCustomerService(
            SharpCrudContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<CustomerCompositeDto> Find(Guid id)
        {
            var customer = _dbContext.Customers.Find(id);

            return Task.FromResult(new CustomerCompositeDto()
            {
                Id = customer.Id,
                Number = customer.Number,
                Name = customer.Name
            });
        }
    }
}
