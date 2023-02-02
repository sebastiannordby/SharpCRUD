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
    internal class CustomerAssembleResult : AssembleResult
    {
        public Customer Customer { get; set; }
        public List<CustomerAddress> Addresses { get; set; }
    }

    internal class CustomerAssembleService : IAssembleService<CustomerAssembleResult, CustomerDto>
    {
        private SharpCrudContext _dbContext;

        public CustomerAssembleService(SharpCrudContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<CustomerAssembleResult> Assemble(CustomerDto dto)
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

            return Task.FromResult(new CustomerAssembleResult()
            {
                Customer = processedCustomer
            });
        }
    }
}
