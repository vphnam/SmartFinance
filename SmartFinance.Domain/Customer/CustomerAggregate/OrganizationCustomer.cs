using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public sealed class OrganizationCustomer: Customer
    {
        public string OrganizationName { get; set; }
        public string ContactPerson { get; set; }

        public OrganizationCustomer(string customerNumber, string phoneNumber, string emailAddress, string brokerId, string organizationName, string contactPerson) : base(customerNumber, phoneNumber, emailAddress, brokerId)
        {
            OrganizationName = customerNumber;
            ContactPerson = contactPerson;
        }
    }
}
