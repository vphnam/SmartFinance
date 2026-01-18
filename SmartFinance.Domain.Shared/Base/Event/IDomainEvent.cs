using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinance.Domain.Shared.Base.Event
{
    public interface IDomainEvent
    {
        DateTime OccuredDate { get; }
    }
}
