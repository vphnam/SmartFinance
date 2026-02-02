using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Domain.Shared.Base;
using SmartFinance.Infrastructure.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Configurations.CustomerConfigurations
{
    public class PersonalCustomerConfiguration : EntityBaseConfiguration<PersonalCustomer, Guid>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PersonalCustomer> builder)
        {
            //base.Configure(builder);
            var tableName = "PersonalCustomer";
            builder.ToTable(tableName);
            builder.Property(e => e.CustomerName)
                .HasMaxLength(200);
            builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);
            builder.Property(e => e.EmailAddress)
            .HasMaxLength(100);
            builder.Property(e => e.BrokerId)
            .HasMaxLength(20);
            builder.Property<Boolean>("IsActive");

            // Shadow properties (audit fields)
            builder.Property<DateTime>("CreatedDate")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

            builder.Property<DateTime>("UpdatedDate")
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
