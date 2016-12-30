using System.Linq;
using GenericRepository;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.Repositories
{
    public interface IAuthorRepository : IRepository<Author>, IRepositoryDisconnected<Author>
    {
        IQueryable<Author> Authors { get; }

    }
}
