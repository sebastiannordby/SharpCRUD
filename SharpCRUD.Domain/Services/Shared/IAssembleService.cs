using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.Shared
{
    internal abstract class AssembleResult
    {

    }

    internal interface IAssembleService<TAssembleResult, TFromDto>
        where TAssembleResult : AssembleResult
    {
        Task<TAssembleResult> Assemble(TFromDto dto);
    }
}
