using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.User
{
    public class User: EntityBase<Guid>
    {
        public string ReferenceId { get; set; }
        public string UserName { get;set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }

        public User(string referenceId, string userName, string email, string phoneNumber): base(Guid.NewGuid())
        {
            ReferenceId = referenceId;
            UserName = userName;
            EmailAddress = email;
            PhoneNumber = phoneNumber;
            IsActive = true;
        }
    }
}
