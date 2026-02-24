using Microsoft.EntityFrameworkCore;
using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.DatabaseContext
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext()
        {
        }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public DbSet<GeneratedNumberResult> GeneratedNumberResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneratedNumberResult>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
