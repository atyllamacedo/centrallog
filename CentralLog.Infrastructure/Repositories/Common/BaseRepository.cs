using CentralLog.Infrastructure.Context;
using CentraLog.ApplicationCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralLog.Infrastructure.Repositories.Common
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;
        private DbSet<TEntity> DbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList().GetRange(1, 50);
        }
        public virtual TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
            return entity;
        }
        public virtual async Task<TEntity> AddLogAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync() > 0);
        }
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public virtual IQueryable<TEntity> SelectFrom(Expression<Func<TEntity, bool>> predicate)
        {
            var result = DbSet.Where(predicate);
            return result;
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();

        }
    }
}
