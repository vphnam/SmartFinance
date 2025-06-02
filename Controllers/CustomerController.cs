using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SF.Application.Contracts.Customers;
using SF.Application.Contracts.Customers.Dto;
using SF.Domain.Shared.Base;

namespace SmartFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerController>
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService,
                                 CommonInjectableService<CustomerController> commonInjectableService) : base(commonInjectableService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetAll()
        {
            try
            {
                return await _customerService.GetAllCustomers();
            }
            catch (Exception ex)
            {
                {
                    Logger.LogError("GetAll::ERROR", ex);
                    return null;
                }
            }
        }
    }
}
