using StepWars.DataAccess.Enitites;
using StepWars.DataAccess.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.DataAccess.Repository.Implementation
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext dbContext;

        public EFRepository(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return includes.Aggregate(dbContext.Set<TEntity>().AsQueryable(),
                (current, includeProperty) =>
                    current.Include(includeProperty)).AsEnumerable();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
