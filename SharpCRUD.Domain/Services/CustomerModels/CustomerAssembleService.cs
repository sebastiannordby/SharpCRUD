using SharpCRUD.DataAccess;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Services.Shared;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class CustomerAssembleService : IAssembleService<Customer, CustomerDto>
    {
        private SharpCrudContext _dbContext;

        public CustomerAssembleService(SharpCrudContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<Customer> Assemble(CustomerDto dto)
        {
            var processedCustomer = _dbContext.Customers.Find(dto.Id);

            if(processedCustomer != null)
            {
                processedCustomer.Update(
                    name: dto.Name);
            }
            else
            {
                processedCustomer = new Customer(
                    id: dto.Id,
                    number: dto.Number,
                    name: dto.Name
                );
            }

            return Task.FromResult(processedCustomer);
        }
    }
}
