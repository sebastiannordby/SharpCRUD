using SharpCRUD.Library.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Repositories.Customer
{
    public interface ICustomerRepository
    {
        Task<Guid> Save(CustomerDto customer);
    }
}
