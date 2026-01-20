using Microsoft.Extensions.DependencyInjection;
using SmartFinance.Application.Contracts.Customers;
using SmartFinance.Application.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCoreService(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}
