using System.Linq;
using GenericRepository;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        IQueryable<Author> Authors { get; }

    }
}
