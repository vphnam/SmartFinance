using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Infrastructure.Data.Customer
{
    public class MerchantRepository : Repository<Merchant, CustomerDbContext>, IMerchantRepository
    {
        public MerchantRepository(CustomerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
