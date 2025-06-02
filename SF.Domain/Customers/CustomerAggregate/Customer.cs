using SF.Domain.Shared.Base;
using System;
using System.Collections.Generic;

namespace SF.Domain.Customers.CustomerAggregate;

public partial class Customer: EntityBase
{
    public string CustomerNumber { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;
}
