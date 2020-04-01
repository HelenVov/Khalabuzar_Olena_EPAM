using TravelAgency.DataAccess.Models;

namespace TravelAgency.DataAccess.Interfaces
{
    public interface ICommandRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

    }
}
