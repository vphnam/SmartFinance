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
        public virtual DbSet<OrganizationCustomer> OrganizationCustomers { get; set; }
        public virtual DbSet<PersonalCustomer> PersonalCustomers { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Broker> Brokers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CustomerDbContext).Assembly);
        }
    }
}
