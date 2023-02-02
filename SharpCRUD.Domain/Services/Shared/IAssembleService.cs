using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.Shared
{
    internal interface IAssembleService<TEntity, TFromDto>
    {
        Task<TEntity> Assemble(TFromDto dto);
    }
}
