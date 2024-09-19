using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;
using System.Collections.Generic;

namespace LoginProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private IOrderService _orderService;
        private IMapper _mapper;
        public orderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            Order newOrder = await _orderService.addOrder(order);
            OrderDto newOrderDto = _mapper.Map<Order, OrderDto>(newOrder);
            if (newOrderDto != null)
                return Ok(newOrderDto);
            return BadRequest();
        }





    }
}
