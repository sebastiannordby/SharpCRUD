using SharpCRUD.DataAccess.Models;
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

    internal class EntityAssembleResult<TEntity>
        where TEntity : BaseEntity
    {
        internal TEntity Model { get; private set; }
        internal bool IsNew { get; private set; }

        internal EntityAssembleResult(TEntity model, bool isNew)
        {
            Model = model;
            IsNew = isNew;
        }
    }

    internal interface IAssembleService<TAssembleResult, TFromDto>
        where TAssembleResult : AssembleResult
    {
        Task<TAssembleResult> Assemble(TFromDto dto);
    }
}
