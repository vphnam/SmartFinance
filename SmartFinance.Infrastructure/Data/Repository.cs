using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Data
{
    public class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : EntityBase<Guid> where TDbContext : DbContext
    {
        protected readonly TDbContext _dbContext;
        public Repository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> FindAsync(string id)
        {
            var obj = await _dbContext.Set<TEntity>().FindAsync(id);
            if (obj == null)
            {
                return null;
            }
            else
                return obj;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = _dbContext.Set<TEntity>().Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public async Task<bool> IsAnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(predicate);
        }

        public async Task<TEntity> FindByExpressionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
    }        
}
