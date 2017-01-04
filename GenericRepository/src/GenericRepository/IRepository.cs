using System.Collections.Generic;
using System.Linq;

namespace GenericRepository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        IQueryable<TEntity> Include(params string[] paths);


        TEntity Add(TEntity entity);
        void Add(IEnumerable<TEntity> entities);
        void Add(params TEntity[] entities);

        TEntity Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Update(params TEntity[] entities);

        TEntity Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        void Delete(params TEntity[] entities);
    }
}
