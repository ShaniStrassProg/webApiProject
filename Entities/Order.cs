﻿//using System;
using System.Collections.Generic;

namespace Repositories;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int OrderSum { get; set; }

    public int UserId { get; set; }

    //public List<int> OrderItemId { get; set; } = new List<int>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
