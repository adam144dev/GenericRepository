using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GenericRepository
{
    public class EFRepository<TEntity> :
        IRepository<TEntity>,
        IRepositoryDisconnected<TEntity>
        where TEntity : class, IEntityId
    {
        protected readonly DbContext _dbContext;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Entities => _dbContext.Set<TEntity>();

        public virtual IQueryable<TEntity> Include(params string[] paths)
        {
            IQueryable<TEntity> dbQuery = _dbContext.Set<TEntity>();

            foreach (string path in paths)
                dbQuery = dbQuery.Include(path);

            return dbQuery;
        }


        public void Add(params TEntity[] entities)
        {
            _dbContext.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update(params TEntity[] entities)
        {
            _dbContext.UpdateRange(entities);
            _dbContext.SaveChanges();
        }

        public void Delete(params TEntity[] entities)
        {
            _dbContext.RemoveRange(entities);
            _dbContext.SaveChanges();
        }
        public void Delete(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
            _dbContext.SaveChanges();
        }


        /// <summary>
        /// IRepositoryDisconnected<TEntity>
        /// </summary>

        public void UpdateDisconnected(params TEntity[] entities)
        {
            throw new NotImplementedException(nameof(UpdateDisconnected));
        }


        public void DeleteDisconnected(params int[] entitiesId)
            => Delete(_dbContext.Set<TEntity>().Where(e => entitiesId.Contains(e.Id)));

        public void DeleteDisconnected(params TEntity[] entities)
            => DeleteDisconnected(entities.Select(e => e.Id).ToArray());
        
        public void DeleteDisconnected(IEnumerable<TEntity> entities)
            => DeleteDisconnected(entities.Select(e => e.Id).ToArray());
        
        //// TODO - consider: for optimization only variant
        //private void DeleteDisconnected(int entityId)
        //{
        //    var entityFound = _dbContext.Set<TEntity>().Find(entityId);
        //    if (entityFound != null)
        //        Delete(entityFound);
        //}
    }
}
