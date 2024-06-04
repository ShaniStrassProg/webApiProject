//using Entities;
using Repositories;
using System.Data;

namespace Services
{
    public class CategoryService : ICategoryService

    {
       private ICategoryRepository _categoryRepository;

       public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<Category> addCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> getCategories()
        {
            return await _categoryRepository.getCategories();
            
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> updateCategory(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
