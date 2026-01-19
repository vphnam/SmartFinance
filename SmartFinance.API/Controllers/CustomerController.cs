using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartFinance.Application.Contracts.Customers;
using SmartFinance.Application.Contracts.Customers.Dto;

namespace SmartFinance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerListDto>> GetCustomer()
        {
            return await _customerService.GetTop100Customer();
        }
    }
}
