using SharpCRUD.Shared.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API.Repositories.Customer
{
    public interface ICustomerRepository
    {
        Task<Guid> Save(CustomerDto customer);
    }
}
