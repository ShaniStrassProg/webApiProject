//using Entities;
using DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
   
{
    public class CategoryRepository : ICategoryRepository
    {
        private PhotoGalleryContext _photoGalleryContext;
        public CategoryRepository(PhotoGalleryContext photoGalleryContext)
        {
            _photoGalleryContext = photoGalleryContext;
        }


        public async Task<List<Category>> getCategories()
        {
            var foundCategories = await _photoGalleryContext.Categories.ToListAsync();
            if (foundCategories == null)
                return null;
            return foundCategories;
        }

        public Task<CategoryDto> getCategoryById(int id)
        {
            throw new NotImplementedException();
        }
        //public async Task<List<Product>> getProducts(int position,int skip,string? desc,int? minPrice
        //    ,int maxPrice, int?[] categoryIds )
        //{
        //    var query =  _photoGalleryContext.Products.Where(product=>
        //    (desc==null ? (true) : (product.Description.Contains(desc)))
        //        && ((minPrice==null)? (true) :(product.Price >= minPrice))
        //        && ((maxPrice==null)? (true) : (product.Price<= maxPrice))
        //        &&((categoryIds.Length==0) ? (true) : (categoryIds.Contains(product.CategoryId))))
        //        .OrderBy(Product => Product.Price);
        //    //.Skip((position-1)*skip)
        //    //.Take(skip);
        //    Console.WriteLine(query.ToQueryString());
        //    List<Product> products = await query.ToListAsync();
        //    return products;



        //   ;

        //}

        //public async Task<Product> getProductById(int id)
        //{
        //    var foundProduct = await _photoGalleryContext.Products.FindAsync(id);
        //    if (foundProduct == null)
        //        return null;
        //    return foundProduct;
        //}

    }
}
