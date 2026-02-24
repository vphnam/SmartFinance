using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Contracts.Shared
{
    public interface IEmailService
    {
        Task SendMailAsync(string to, string subject, string body);
    }
}
