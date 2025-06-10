using SF.Application.Contracts.Customers;
using SF.Application.Contracts.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Domain.Customers.CustomerAggregate;
using System.Diagnostics.CodeAnalysis;

namespace SF.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            var custList = await _customerRepository.GetAllAsync(); 
            return custList.Select(n => new CustomerDto(n.CustomerNumber, n.CustomerName, n.Email, n.Address)).ToList();
            
        }
    }
}
