using System.Collections.Generic;
using System.Linq;

namespace GenericRepository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        IQueryable<TEntity> Include(params string[] paths);


        void Add(params TEntity[] entities);

        void Update(params TEntity[] entities);

        void Delete(params TEntity[] entities);
        void Delete(IEnumerable<TEntity> entities);

    }
}
