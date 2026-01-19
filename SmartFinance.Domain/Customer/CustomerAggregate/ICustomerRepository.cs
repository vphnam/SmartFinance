using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
