using System.Linq;
using GenericRepositorySample.Models;
using GenericRepository;

namespace GenericRepositorySample.Repositories
{
    public interface ICategoryRepository : IRepository<Category>, IRepositoryDisconnected<Category>
    {
        IQueryable<Category> Categories { get; }
    }
}
