using TravelAgency.DataAccess.Models;

namespace TravelAgency.DataAccess.Interfaces
{
    public interface IRepository<TEntity> :ICommandRepository<TEntity>,IQueryRepository<TEntity> where TEntity : BaseEntity
    {
        
    }
}