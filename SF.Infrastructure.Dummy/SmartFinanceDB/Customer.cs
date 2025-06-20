﻿using System;
using System.Collections.Generic;

namespace SmartFinance.SmartFinanceDB;

public partial class Customer
{
    public string CustomerNumber { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;
}
