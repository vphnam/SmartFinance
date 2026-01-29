using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Infrastructure.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Configurations
{
    public class PersonalCustomerConfiguration : EntityBaseConfiguration<Customer, Guid>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            var tableName = "Customer";

            builder.ToTable(tableName);

            builder.HasIndex(e => e.CustomerNumber)
                  .IsUnique();

            builder.Property(e => e.CustomerNumber)
                .HasMaxLength(20);

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
