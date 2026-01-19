using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Data.Customer
{
    public class CustomerRepository : Repository<SmartFinance.Domain.Customer.CustomerAggregate.Customer, SFDbContext>, ICustomerRepository
    {
        public CustomerRepository(SFDbContext dbContext) : base(dbContext)
        {
        }
    }
}
