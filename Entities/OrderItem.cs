﻿using System;
using System.Collections.Generic;

namespace Repositories;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quaninty { get; set; }

    //public virtual Order Order { get; set; } = null!;

    //public virtual Product Product { get; set; } = null!;
}
