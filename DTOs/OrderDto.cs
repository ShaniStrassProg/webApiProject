using System;
using System.Collections.Generic;

namespace DTO;
 
public partial class OrderDto
{
    //public int OrderId { get; set; }

    //public DateOnly? OrderDate { get; set; }

    public int OrderSum { get; set; }

    public int UserId { get; set; }

    //public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    public virtual ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    //public virtual User User { get; set; } = null!;
}
