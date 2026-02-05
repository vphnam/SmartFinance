using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.User;
using SmartFinance.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Data.User
{
    public class UserRoleRepository : Repository<UserRole, UserDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(UserDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<string>> GetRolesOfUser(Guid userId)
        {
            var roles = await _dbContext.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(_dbContext.Roles,
                       ur => ur.RoleId,
                       r => r.Id,
                       (_, r) => r.RoleName)
                .AsNoTracking()
                .ToListAsync();

            return roles;
        }
    }
}
