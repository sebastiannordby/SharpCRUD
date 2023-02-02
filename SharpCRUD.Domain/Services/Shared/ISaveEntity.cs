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
            var dbSet = _dbContext.Set<TEntity>();
            var shouldUpdate = dbSet.Any(x => x.Id == entity.Id);

            if(shouldUpdate)
            {
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Add(entity);
            }

            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
