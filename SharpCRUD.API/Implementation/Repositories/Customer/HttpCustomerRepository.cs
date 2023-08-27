using SharpCRUD.API.Repositories.Customer;
using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API.Implementation.Repositories.Customer
{
    internal sealed class HttpCustomerRepository : ICustomerRepository
    {
        public Task<Guid> Save(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
