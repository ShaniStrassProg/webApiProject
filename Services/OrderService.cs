using DTO;
//using Entities;

using Repositories;
using System.Data;
using Zxcvbn;
namespace Services
{
    public class OrderService : IOrderService

    {
        private IOrderRepository _orderRepository;
       public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> addOrder(Order order)
        {
            order.OrderDate =  DateOnly.FromDateTime(DateTime.Now.Date);
            return await _orderRepository.addOrder(order);
        }

       
        
    }
}
