//using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> getProductById(int id);

        Task<List<Product>> getAllProducts();
        
    }
}