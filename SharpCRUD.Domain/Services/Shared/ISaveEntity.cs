using SharpCRUD.Domain;
using SharpCRUD.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Services.Shared
{
    internal interface ISaveEntity<TEntity>
        where TEntity : BaseEntity
    {
        Task Save(TEntity entity);
    }
}
