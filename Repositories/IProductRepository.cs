//using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> getProductById(int id);

        Task<List<Product>> getProducts(int position, int skip, string? desc, int? minPrice
            , int? maxPrice, int?[] categoryIds);


    }
}