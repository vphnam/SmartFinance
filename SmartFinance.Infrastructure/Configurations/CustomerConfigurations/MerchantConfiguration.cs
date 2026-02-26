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
    public class MerchantConfiguration : EntityBaseConfiguration<Merchant, Guid>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Merchant> builder)
        {
            base.Configure(builder);
            var tableName = "Merchant";

            builder.ToTable(tableName);

            builder.HasIndex(e => e.MerchantNumber)
                  .IsUnique();

            builder.Property(e => e.MerchantNumber)
                .HasMaxLength(10);

            builder.Property(e => e.MerchantName)
                .HasMaxLength(200);

            builder.Property(e => e.ContactNumber)
            .HasMaxLength(20);

            builder.Property(e => e.EmailAddress)
            .HasMaxLength(100);

            builder.Property(e => e.TaxNumber)
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
