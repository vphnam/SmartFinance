using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.User;
using SmartFinance.Infrastructure.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Configurations.IdentityConfigurations
{
    public class RoleConfiguration : EntityBaseConfiguration<Role, Guid>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            var tableName = "Role";
            builder.ToTable(tableName);
            builder.Property(e => e.RoleName)
                .HasMaxLength(100);
            builder.Property(e => e.Description)
                .HasMaxLength(200);
        }
    }
}
