using System.Linq;
using GenericRepositorySample.Models;
using GenericRepository;

namespace GenericRepositorySample.Repositories
{
    public interface IBookRepository : IRepository<Book>, IRepositoryDisconnected<Book>
    {
        IQueryable<Book> Books { get; }
    }
}
