using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.Shared
{
    public interface ISaveService<TDto>
    {
        Task<Guid> Save(TDto model);
    }
}
