using System.Linq;
using GenericRepository;
using GenericRepositorySample.DAL;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.Repositories
{
    public class EFBookRepository : EFBaseRepository<Book>, IBookRepository
    {
        public EFBookRepository(GenericRepositorySampleDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Book> Books => Entities;

    }
}
