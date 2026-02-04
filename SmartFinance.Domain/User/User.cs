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
        public string ReferenceId { get; private set; }
        public string UserName { get; private set; }
        public string EmailAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }

        internal User(string referenceId, string userName, string emailAddress, string phoneNumber, string passwordHash) : base(Guid.NewGuid())
        {
            ReferenceId = referenceId;
            UserName = userName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            IsActive = true;
        }

        public static User Create(string referenceId, string userName, string emailAddress, string phoneNumber, string passwordHash)
        {
            return new User(
                referenceId: referenceId,
                userName: userName,
                emailAddress: emailAddress,
                phoneNumber: phoneNumber,
                passwordHash: passwordHash
            );
        }
    }
}
