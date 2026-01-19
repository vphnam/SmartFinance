using SmartFinance.Application.Contracts.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Application.Contracts.Customers
{
    public interface ICustomerService
    {
        Task<List<CustomerListDto>> GetTop100Customer();
    }
}
