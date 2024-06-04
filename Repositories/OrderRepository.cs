using DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
   
{
    public class OrderRepository : IOrderRepository
    {
        private PhotoGalleryContext _photoGalleryContext;
        public OrderRepository(PhotoGalleryContext photoGalleryContext)
        {
            _photoGalleryContext = photoGalleryContext;
        }
   
    


        public async Task<Order> addOrder(Order order)
        {
            await _photoGalleryContext.Orders.AddAsync(order);
            await _photoGalleryContext.SaveChangesAsync();
            return order;
        }

    
    }
}
