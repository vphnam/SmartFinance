using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Identity;
using SmartFinance.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Data.Identity
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IdentityDbContext _identityDbContext;
        public IdentityRepository(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }
        public Task<string> GenerateNextNumberAsync(string sequenceName, string prefix)
        {
            var result = _identityDbContext.GeneratedNumberResults.FromSqlRaw("EXECUTE dbo.GenerateNextNumber @SequenceName, @Prefix", sequenceName, prefix)
                .AsNoTracking()
                .FirstOrDefault();

            return result
        }
    }
}
