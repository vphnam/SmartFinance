using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartFinance.Domain.User;
using SmartFinance.Infrastructure.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Configurations.IdentityConfigurations
{
    public class UserConfiguration : EntityBaseConfiguration<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            var tableName = "User";
            builder.ToTable(tableName);

            builder.Property(e => e.ReferenceId)
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(e => e.UserName)
                .HasMaxLength(100);
            builder.Property(e => e.EmailAddress)
                .HasMaxLength(100);
            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.IsActive)
                .IsRequired();
        }
    }
}
