using System.Linq;
using GenericRepository;
using GenericRepositorySample.DAL;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.Repositories
{
    public class EFCategoryRepository : EFBaseRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(GenericRepositorySampleDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Category> Categories => Entities;

    }
}
