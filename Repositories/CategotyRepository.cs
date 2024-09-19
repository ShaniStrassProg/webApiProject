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
        
    }
}
