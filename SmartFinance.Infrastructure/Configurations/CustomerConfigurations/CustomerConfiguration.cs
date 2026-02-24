using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Infrastructure.Configurations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Configurations.CustomerConfigurations
{
    public class CustomerConfiguration : EntityBaseConfiguration<Customer, Guid>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            var tableName = "Customer";

            builder.ToTable(tableName);

            builder.HasIndex(e => e.CustomerNumber)
                  .IsUnique();

            builder.Property(e => e.CustomerNumber)
                .HasMaxLength(10);

            builder.Property(e => e.FullName)
                .HasMaxLength(200);

            builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);

            builder.Property(e => e.EmailAddress)
            .HasMaxLength(100);

            builder.Property(e => e.TaxNumber)
            .HasMaxLength(20);

            builder.Property(e => e.CustomerType)
            .HasMaxLength(20);

            builder.Property(e => e.MerchantId)
            .HasMaxLength(20);

            builder.Property<bool>("IsActive");

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
