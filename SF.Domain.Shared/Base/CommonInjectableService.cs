using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Domain.Shared.Base
{
    public class CommonInjectableService<TLogger>
    {
        public readonly ILogger<TLogger> Logger;
        public CommonInjectableService(ILogger<TLogger> logger) 
        {
            Logger = logger;
        }
    }
}
