using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.DataAccess.Repository
{
    public class TEntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TravelAgencyContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public TEntityRepository(TravelAgencyContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

        }
        public TEntity Add(TEntity entity)
        {
            var created = _dbSet.Add(entity);
            _context.SaveChanges();

            return created;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = _dbSet.FirstOrDefault(o => o.Id == id);
            if (obj != null)
            {
                _dbSet.Remove(obj);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TEntity> GetAll(int? skip = null, int? take = null)
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(o => o.Id == id);
        }


        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }
    }
}