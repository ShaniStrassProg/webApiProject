using DTO;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
   
{
    public class UserRepository : IUserRepository
    {
        private PhotoGalleryContext _photoGalleryContext;
        public UserRepository(PhotoGalleryContext photoGalleryContext)
        {
            _photoGalleryContext = photoGalleryContext;
        }

        public async Task<User> GetUserByEmailAndPassword(User userLogin)
        {
           return await _photoGalleryContext.Users.Where(e => e.Email == userLogin.Email && e.Password == userLogin.Password).FirstOrDefaultAsync();
         

        }

        public async Task<User> addUser(User user)
        {
            
            
                await _photoGalleryContext.Users.AddAsync(user);
                await _photoGalleryContext.SaveChangesAsync();
                return user;
          
        }


        public async Task<User> updateUser(int id, User userToUpdate)
        {
 
            userToUpdate.UserId = id;
            _photoGalleryContext.Update(userToUpdate);
            await _photoGalleryContext.SaveChangesAsync();
            return userToUpdate;
        }


    }
}
