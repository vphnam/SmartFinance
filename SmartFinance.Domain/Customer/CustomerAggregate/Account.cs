using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public class Account : EntityBase<Guid>
    {
        public string CustomerId { get;set; }
        public string AccountNumber { get; set; }
        public string Platform { get; set; }
        public string AccountType { get; set; }
        public string BaseCurrency { get; set; }
        public bool IsActive { get; set; }

        public Account(string customerId, string accountNumber, string platform, string accountType, string baseCurrency) : base(Guid.NewGuid())
        {
            CustomerId = customerId;
            AccountNumber = accountNumber;
            Platform = platform;
            AccountType = accountType;
            BaseCurrency = baseCurrency;
            IsActive = true;
        }
    }
}
