//using Entities;
using DTO;


namespace Repositories
{
    public interface ICategoryRepository
    {
        //Task<User> addUser(User user);
        Task<CategoryDto> getCategoryById(int id);
        Task<List<Category>> getAllCategories();
        //Task<User> updateUser(int id, User userToUpdate);
    }
}