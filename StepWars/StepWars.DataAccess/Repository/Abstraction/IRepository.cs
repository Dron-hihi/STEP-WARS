using StepWars.DataAccess.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StepWars.DataAccess.Repository.Abstraction
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll();

        //predicate = ( x => x.Price > 100 )
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
    }
}
