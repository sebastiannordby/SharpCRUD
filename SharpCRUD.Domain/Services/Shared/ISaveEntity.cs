using SharpCRUD.DataAccess;
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

    internal class GenericSaveEntityService<TEntity> : ISaveEntity<TEntity>
        where TEntity : BaseEntity
    {
        private readonly SharpCrudContext _dbContext;

        public GenericSaveEntityService(SharpCrudContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task Save(TEntity entity)
        {
            if(entity.IsNew)
            {
                _dbContext.Set<TEntity>().Add(entity);
            }
            else
            {
                _dbContext.Set<TEntity>().Update(entity);
            }

            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
