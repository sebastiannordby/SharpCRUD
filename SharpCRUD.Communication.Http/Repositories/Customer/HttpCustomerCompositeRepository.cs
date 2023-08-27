using SharpCRUD.Communication.Http.Tools;
using SharpCRUD.Communication.Repositories.CustomerModels;
using SharpCRUD.Library.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Communication.Http.Repositories.Customer
{
    internal class HttpCustomerCompositeRepository : ICustomerCompositeRepository
    {
        private readonly ISharpCRUDHttpClientTask _httpTask;

        public HttpCustomerCompositeRepository(ISharpCRUDHttpClientTask httpTask)
        {
            _httpTask = httpTask;
        }
    }
}
