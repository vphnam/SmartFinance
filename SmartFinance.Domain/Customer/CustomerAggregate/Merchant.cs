using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public class Merchant: EntityBase<Guid>
    {
        public string MerchantNumber { get; set; }
        public string MerchantName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string TaxNumber { get; set; }
        public Merchant(string merchantNumber, string merchantName, string contactNumber, string emailAddress, string taxNumber) : base(Guid.NewGuid())
        {
            MerchantNumber = merchantNumber;
            MerchantName = merchantName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            TaxNumber = taxNumber;
        }
    }
}
