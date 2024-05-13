//using Entities;
using Repositories;
using System.Data;

namespace Services
{
    public class ProductService : IProductService

    {
       private IProductRepository _productRepository;

       public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
      
        public async Task<Product> getProductById(int id)
        {
            return await _productRepository.getProductById(id);
        }
        public async Task<List<Product>> getAllProducts()
        {
            return await _productRepository.getAllProducts();
        }


    }
}
