//using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace Repositories
   
{
    public class ProductRepository : IProductRepository
    {
        private PhotoGalleryContext _photoGalleryContext;
        public ProductRepository(PhotoGalleryContext photoGalleryContext)
        {
            _photoGalleryContext = photoGalleryContext;
        }
        public async Task<List<Product>> getAllProducts()
        {
            var products = await _photoGalleryContext.Products.ToListAsync();
            if (products == null)
                return null;
            return products;

        }

        public async Task<Product> getProductById(int id)
        {
            var foundProduct = await _photoGalleryContext.Products.FindAsync(id);
            if (foundProduct == null)
                return null;
            return foundProduct;
        }

    }
}
