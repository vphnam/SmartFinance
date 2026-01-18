using Microsoft.EntityFrameworkCore;
using SmartFinance.Infrastructure.Models;


namespace SmartFinance.Infrastructure.DatabaseContext
{
    public class SFDbContext : DbContext
    {
        public SFDbContext()
        {
        }
        
        public SFDbContext(DbContextOptions<SFDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                .IsRequired();

                entity.Property(e => e.CustomerId)
                .IsRequired()
                .HasMaxLength(10);

                entity.HasIndex(e => e.CustomerNumber)
                      .IsUnique();

                entity.Property(e => e.CustomerName)
                .HasMaxLength(200);

                entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20);

                entity.Property(e => e.EmailAddress)
                .HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.UpdatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
