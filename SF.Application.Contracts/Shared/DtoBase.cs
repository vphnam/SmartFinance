using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Application.Contracts.Shared
{
    [Serializable]
    public class DtoBase
    {
        public DateTime Updated { get; set; }
        public DtoBase() 
        {
            Updated = DateTime.Now;
        }
    }
}
