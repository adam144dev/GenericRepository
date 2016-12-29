using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository
{
    public class EFBaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public EFBaseRepository(DbContext dbContext)
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
            foreach (var entity in entities)
                _dbContext.Add(entity);

            _dbContext.SaveChanges();
        }

        public void Update(params TEntity[] entities)
        {
            foreach (var entity in entities)
                _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }

        public void Delete(params TEntity[] entities)
        {
            foreach (var entity in entities)
                _dbContext.Remove(entity);

            _dbContext.SaveChanges();
        }
    }
}
