
using CentraLog.ApplicationCore.Interfaces.Repositories;
using CentraLog.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CentraLog.ApplicationCore.Services.Common
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
    {
        private readonly IBaseRepository<TEntity> _repository;
        protected BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TEntity> GetAll()
        {
            var result = new List<TEntity>();
            try
            {
                result = _repository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        public TEntity Add(TEntity entity)
        {
            return _repository.Add(entity);

        }
        public async Task<TEntity> AddLogAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }
            TEntity entityAffected = await _repository.AddLogAsync(entity);

            return entityAffected;
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> result = null;
            try
            {
                result = _repository.Find(predicate).ToList();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
        public IQueryable<TEntity> SelectFrom(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate.ToString().Contains("delete"))
            {
                throw new ArgumentNullException(paramName: nameof(string.Empty));
            }
            var select = _repository.SelectFrom(predicate);
            return select;
        }
        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }
    }
}
