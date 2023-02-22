using SharpCRUD.DataAccess;
using SharpCRUD.DataAccess.Models.CustomerModels;
using SharpCRUD.Domain.Extensions;
using SharpCRUD.Domain.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.CustomerModels
{
    internal class CustomerNumberService : IEntityNumberService<Customer>
    {
        private readonly SharpCrudContext _context;

        public CustomerNumberService(SharpCrudContext context)
        {
            _context = context;
        }

        public Task<int> GetRequestedOrNewNumber(int requestedNumber = -1)
        {
            var numberSequence = _context.Customers
                .Select(x => x.Number);

            return Task.FromResult(numberSequence
                .SelectRequestedNumberOrLowestAvailable(requestedNumber));
        }
    }
}
