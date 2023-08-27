using SharpCRUD.Communication.Http.Tools;
using SharpCRUD.Communication.Repositories.CustomerModels;
using SharpCRUD.Library.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Http.Repositories.Customer
{
    internal sealed class HttpCustomerRepository : ICustomerRepository
    {
        private readonly ISharpCRUDHttpClientTask _httpTask;

        public HttpCustomerRepository(ISharpCRUDHttpClientTask httpTask)
        {
            _httpTask = httpTask;
        }

        public async Task<Guid> Save(CustomerDto customer)
        {
            return await _httpTask.Post<Guid>(
                "Customer/Save", customer);
        }
    }
}
