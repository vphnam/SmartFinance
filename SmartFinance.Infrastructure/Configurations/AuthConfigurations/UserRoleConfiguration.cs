using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartFinance.Domain.User;
using SmartFinance.Infrastructure.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Configurations.AuthConfigurations
{
    public class UserRoleConfiguration : EntityBaseConfiguration<UserRole, Guid>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);
            var tableName = "UserRole";
            builder.ToTable(tableName);

            builder.Property(e => e.UserId)
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(e => e.RoleId)
                .HasMaxLength(36)
                .IsRequired();
        }
    }
}
