using Microsoft.AspNetCore.Mvc;
using SF.Domain.Shared.Base;

namespace SmartFinance.Controllers
{
    public class BaseController<T>: ControllerBase
    {
        private readonly CommonInjectableService<T> _service;
        public ILogger<T> Logger => _service.Logger;

        public BaseController(CommonInjectableService<T> service)
        {
            _service = service;
        }
    }
}
