using SmartFinance.Domain.User;
using SmartFinance.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Data.User
{
    public class UserRepository : Repository<SmartFinance.Domain.User.User, UserDbContext>, IUserRepository
    {
        public UserRepository(UserDbContext dbContext) : base(dbContext)
        {
        }
    }
}
