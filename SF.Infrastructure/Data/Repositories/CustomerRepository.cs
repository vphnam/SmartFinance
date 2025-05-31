using Microsoft.EntityFrameworkCore;
using SF.Domain.Customers.CustomerAggregate;
using SF.Infrastructure.Data.Base;
using SF.Infrastructure.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Infrastructure.Data.Repositories
{
    public class CustomerRepository : Repository<Customer, CustomerOracleDbContext>, ICustomerRepository
    {
        public CustomerRepository(CustomerOracleDbContext oracledb) : base(oracledb)
        {
        }
    }
}
