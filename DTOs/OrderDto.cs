using System;
using System.Collections.Generic;

namespace DTO;
 
public partial class OrderDto
{

    public int OrderSum { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

}
