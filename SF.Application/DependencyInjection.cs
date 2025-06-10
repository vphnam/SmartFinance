using Microsoft.Extensions.DependencyInjection;
using SF.Application.Contracts.Customers;
using SF.Application.Customers;
using SF.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(CommonInjectableService<>), typeof(CommonInjectableService<>));

            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
