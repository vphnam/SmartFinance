using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public class Customer: EntityBase<Guid>, IAggregateRoot
    {
        public string CustomerNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string TaxNumber { get; set; }
        public string CustomerType { get; set; }
        public string MerchantId { get; set; }
        public bool IsActive { get; set; }

        public Customer(string customerNumber, 
                        string fullName,
                        string phoneNumber, 
                        string emailAddress, 
                        string taxNumber,
                        string customerType,
                        string merchantId) : base(Guid.NewGuid())
        {
            CustomerNumber = customerNumber;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            TaxNumber = taxNumber;
            CustomerType = customerType;
            MerchantId = merchantId;
            IsActive = true;
        }

    }
}
