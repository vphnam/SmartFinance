using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Customer.CustomerAggregate
{
    public class Broker: EntityBase<Guid>
    {
        public string BrokerNumber { get; set; }
        public string BrokerName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string LicenseNumber { get; set; }
        public string Platform { get; set; }
        public Broker(string brokerNumber, string brokerName, string contactNumber, string emailAddress, string licenseNumber, string platform) : base(Guid.NewGuid())
        {
            BrokerNumber = brokerNumber;
            BrokerName = brokerName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            LicenseNumber = licenseNumber;
            Platform = platform;
        }
    }
}
