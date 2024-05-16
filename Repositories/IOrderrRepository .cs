using DTO;
//using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order>  addOrder(Order order);
 
    }
}