using System.Linq;

namespace GenericRepository
{
    public interface IEntityId
    {
        int Id { get; }
    }

    public interface IRepositoryDisconnected<TEntity>
       where TEntity : class, IEntityId
    {
        void DeleteDisconnected(params int[] entitiesId);
        void DeleteDisconnected(params TEntity[] entities);
    }
}
