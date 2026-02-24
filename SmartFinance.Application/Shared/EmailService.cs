using Microsoft.Extensions.Configuration;
using SmartFinance.Application.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Shared
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMailAsync(string to, string subject, string body)
        {
            var smtp = new System.Net.Mail.SmtpClient(_configuration["Email:Smtp:Host"], int.Parse(_configuration["Email:Smtp:Port"]))
            {
                Credentials = new System.Net.NetworkCredential(_configuration["Email:Smtp:Username"], _configuration["Email:Smtp:Password"]),
                EnableSsl = bool.Parse(_configuration["Email:Smtp:EnableSsl"])
            };

            var message = new MailMessage(
            _configuration["Email:From"],
            to,
            subject,
            body)
            {
                IsBodyHtml = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}
