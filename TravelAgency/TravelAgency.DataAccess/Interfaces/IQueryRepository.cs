using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.DataAccess.Interfaces
{
    public interface IQueryRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(int? skip = null, int? take = null);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);

    }
}