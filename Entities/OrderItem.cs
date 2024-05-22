using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Repositories;

public  class OrderItem
{
    public int OrderItemId { get; set; }


    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quaninty { get; set; }
    [JsonIgnore]
    public virtual Order? Order { get; set; } = null!;
    [JsonIgnore]
    public virtual Product? Product { get; set; } = null!;
}
