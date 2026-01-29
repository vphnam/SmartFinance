using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public class PersonalCustomer : Customer
    {
        public string CustomerName { get; set; }
        public PersonalCustomer(string customerNumber, string phoneNumber, string emailAddress, string brokerId, string customerName)
            : base(customerNumber, phoneNumber, emailAddress, brokerId)
        {
            CustomerName = customerName;
        }
    }
}
