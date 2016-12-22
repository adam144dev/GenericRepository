using System.Linq;
using GenericRepositorySample.Models;
using GenericRepository;

namespace GenericRepositorySample.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        IQueryable<Category> Categories { get; }
    }
}
