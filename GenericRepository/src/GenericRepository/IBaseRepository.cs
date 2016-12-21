using System.Linq;

namespace GenericRepository
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        IQueryable<TEntity> Include(params string[] paths);


        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
