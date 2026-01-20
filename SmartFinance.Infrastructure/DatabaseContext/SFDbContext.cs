using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Customer.CustomerAggregate;
using System;


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
            modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(SFDbContext).Assembly);
        }
    }
}
