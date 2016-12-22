using System.Linq;
using GenericRepositorySample.Models;
using GenericRepository;

namespace GenericRepositorySample.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IQueryable<Book> Books { get; }
    }
}
