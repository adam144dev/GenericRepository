using System.Linq;
using GenericRepository;
using GenericRepositorySample.DAL;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.Repositories
{
    public class EFCategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public EFCategoryRepository(GenericRepositorySampleDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Category> Categories => Entities;

    }
}
