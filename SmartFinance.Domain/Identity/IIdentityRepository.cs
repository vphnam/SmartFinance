using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Identity
{
    public interface IIdentityRepository
    {
        Task<string> GenerateNextNumberAsync(string sequenceName, string prefix);
    }
}
