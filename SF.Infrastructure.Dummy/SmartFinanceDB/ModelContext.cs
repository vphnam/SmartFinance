using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartFinance.SmartFinanceDB;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("NAMVPH")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerNumber);

            entity.ToTable("CUSTOMER");

            entity.HasIndex(e => e.Email, "SYS_C008669").IsUnique();

            entity.Property(e => e.CustomerNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .IsFixedLength()
                .HasColumnName("CUSTOMER_NUMBER");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EMAIL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
