using System.Linq;
using GenericRepositorySample.DAL;
using GenericRepositorySample.Models;
using GenericRepository;

namespace GenericRepositorySample.Repositories
{
    public class EFAuthorRepository : EFBaseRepository<Author>, IAuthorRepository
    {
        public EFAuthorRepository(GenericRepositorySampleDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Author> Authors => Entities;

    }
}
