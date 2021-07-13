using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CentraLog.ApplicationCore.Interfaces.Services
{
    public interface IBaseService<TEntity>
    {
        IQueryable<TEntity> SelectFrom(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        Task<TEntity> AddLogAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
