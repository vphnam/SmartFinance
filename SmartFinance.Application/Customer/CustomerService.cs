using Microsoft.EntityFrameworkCore;
using SmartFinance.Application.Contracts.Customers;
using SmartFinance.Application.Contracts.Customers.Dto;
using SmartFinance.Domain.Customer.CustomerAggregate;
using SmartFinance.Domain.Shared.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerListDto>> GetTop100Customer()
        {
            // Implementation needed. Returning empty list for now.
            return await _customerRepository.GetQueryable(n => n.CustomerNumber.Contains("C")).Take(100).Select(c => new CustomerListDto
            {
                CustomerId = c.Id,
                CustomerNumber = c.CustomerNumber,
                CustomerName = c.CustomerName,
                PhoneNumber = c.PhoneNumber,
                EmailAddress = c.EmailAddress
            }).ToListAsync();
        }
    }
}
