using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Customer.CustomerAggregate;
using System;


namespace SmartFinance.Infrastructure.DatabaseContext
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {
        }
        
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CustomerDbContext).Assembly, 
            type => type.Namespace!.Contains("CustomerConfigurations"));

            modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CustomerDbContext).Assembly,
            type => type.Namespace!.Contains("MerchantConfigurations"));
        }
    }
}
