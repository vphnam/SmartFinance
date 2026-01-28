using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.User
{
    public class Role: EntityBase<Guid>
    {
        public string RoleName { get; set; }

        public string Description { get; set; }

        public Role(string roleName, string description) : base(Guid.NewGuid())
        {
            RoleName = roleName;
            Description = description;
        }
    }
}
