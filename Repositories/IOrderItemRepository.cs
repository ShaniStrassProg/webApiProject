//using Entities;
using DTO;

namespace Repositories
{
    public interface IOrderItemRepository
    {
        OrderItem addOrderItem(OrderItemDto orderItemDto);
        Task<List<OrderItemDto>> getAllOrderItems();
        //Task<User> updateUser(int id, User userToUpdate);
    }
}