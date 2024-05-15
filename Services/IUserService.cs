using DTO;
//using Entities;
using Repositories;

namespace Services
{
    public interface IUserService
    {
        Task<User> addUser(User user);
        int evalutePassword(string password);
        Task<User> GetUserByEmailAndPassword(User userLogin);
        //Task<UserRegister> getUserById(int id);
        Task<User> updateUser(int id, User userToUpdate);
    }
}