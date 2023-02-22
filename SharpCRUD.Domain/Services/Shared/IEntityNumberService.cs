using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.Shared
{
    public interface IEntityNumberService<TEntity>
    {
        Task<int> GetRequestedOrNewNumber(int requestedNumber = -1);
    }
}
