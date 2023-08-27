using SharpCRUD.Library.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Repositories.CustomerModels
{
    internal interface ICustomerCompositeRepository
    {
        Task<Guid> Save(CustomerCompositeDto customer);
    }
}
