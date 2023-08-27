using SharpCRUD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API.Services
{
    public interface IEditCustomerService
    {
        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <returns></returns>
        Task<EditCustomer> Initialize();

        /// <summary>
        /// Loads an existing Customer.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EditCustomer> Find(Guid id);

        /// <summary>
        /// Add or updates a Customer.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<Guid> Save(EditCustomer customer);
    }
}
