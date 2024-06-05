using DTO;
using Microsoft.Extensions.Logging;

//using Entities;

using Repositories;
using System.Data;
using Zxcvbn;
namespace Services
{
    public class OrderService : IOrderService

    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private readonly ILogger<OrderService> _logger;
       public OrderService(IOrderRepository orderRepository,IProductRepository productRepository,ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Order> addOrder(Order order)
        {
            order.OrderDate =  DateOnly.FromDateTime(DateTime.Now.Date);
            int totalSum = await sumToPay(order.OrderItems);
            if (totalSum != order.OrderSum)
                _logger.LogInformation($"sum to pay isn't equal ${order.UserId}");
            order.OrderSum = totalSum;
            return await _orderRepository.addOrder(order);
        }

       private async Task<int> sumToPay(ICollection<OrderItem> orderItems)
        {
            int totalSum = 0;
            foreach (var orderItem in orderItems)
            {
                Product p = await  _productRepository.getProductById(orderItem.ProductId);
                int price = (int)p.Price;// Calculate the subtotal for each OrderItem and add it to the total sum
                int subtotal = orderItem.Quaninty * price;
                totalSum += subtotal;
            }
            return totalSum;
        } 
        
    }
}
