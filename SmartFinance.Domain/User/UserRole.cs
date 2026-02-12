using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.User
{
    public class UserRole : EntityBase<Guid>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public UserRole(Guid userId, Guid roleId) : base(Guid.NewGuid())
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
