using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// IRepositoryDisconnected<TEntity>
        /// </summary>

        //public void UpdateDisconnected(params TEntity[] entities)
        //{
        //    var r = new List<TEntity>();
        //    foreach (var entity in entities)
        //    {
        //        var e = _dbContext.Set<TEntity>().Find(entity.Id);
        //        if (e != null)
        //            r.Add(e);
        //    }

        //    Update(r.ToArray());
        //}

        public void DeleteDisconnected(params int[] entitiesId)
        {
            //// TODO - consider:
            //if (entitiesId.Length == 1)
            //{   // optimization only variant
            //    DeleteDisconnected(entitiesId[0]);
            //    return;
            //}
            var entitiesFound = _dbContext.Set<TEntity>().Where(e => entitiesId.SingleOrDefault(eId => eId == e.Id ) != 0);
            Delete(entitiesFound.ToArray());
        }

        public void DeleteDisconnected(params TEntity[] entities)
        {
            //// TODO - consider:
            //if (entities.Length == 1)
            //{   // optimization only variant
            //    DeleteDisconnected(entities[0].Id);
            //    return;
            //}
            var entitiesFound = _dbContext.Set<TEntity>().Intersect(entities);
            Delete(entitiesFound.ToArray());
        }

        //// TODO - consider: for optimization only variant
        //private void DeleteDisconnected(int entityId)
        //{
        //    var entityFound = _dbContext.Set<TEntity>().Find(entityId);
        //    if (entityFound != null)
        //        Delete(entityFound);
        //}
    }
}
