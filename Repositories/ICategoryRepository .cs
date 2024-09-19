//using Entities;
using DTO;


namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> getCategoryById(int id);
        
        Task<List<Category>> getCategories();
       
    }
}