using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public abstract class Customer: EntityBase<Guid>, IAggregateRoot
    {
        public string CustomerNumber { get; set; }

        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string BrokerId { get; set; }
        public bool IsActive { get; set; }

    }
}
