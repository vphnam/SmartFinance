using Microsoft.EntityFrameworkCore;
using SF.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Infrastructure.Data.Base
{
    internal class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : EntityBase where TDbContext : DbContext
    {
        protected readonly DbContext _dbContext;
        
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByNumberAsync(string id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
    }
}
