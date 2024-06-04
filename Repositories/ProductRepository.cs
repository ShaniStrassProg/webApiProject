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
        public async Task<List<Product>> getProducts(int position,int skip,string? desc,int? minPrice
            ,int? maxPrice, int?[] categoryIds )
        {
            var query = _photoGalleryContext.Products.Where(product =>
             (desc == null ? (true) : (product.ProductName.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))).OrderBy(product => product.Price);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
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
