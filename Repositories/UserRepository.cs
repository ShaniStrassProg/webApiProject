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
        //public async Task<UserRegister> getUserById(int id)
        //{
        //    var foundUser = await _photoGalleryContext.Users.FindAsync(id);
        //    if (foundUser == null)
        //        return null;
        //    return foundUser;


        //}
        public async Task<User> GetUserByEmailAndPassword(User userLogin)
        {
           return await _photoGalleryContext.Users.Where(e => e.Email == userLogin.Email && e.Password == userLogin.Password).FirstOrDefaultAsync();
         

        }

        public async Task<User> addUser(User user)
        {
            try
            {
                await _photoGalleryContext.Users.AddAsync(user);
                await _photoGalleryContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<User> updateUser(int id, User userToUpdate)
        {
            var foundUser = await _photoGalleryContext.Users.FindAsync(id);
            if (foundUser == null)
                return null;
            _photoGalleryContext.Entry(foundUser).CurrentValues.SetValues(userToUpdate);
            await _photoGalleryContext.SaveChangesAsync();
            return userToUpdate;
        }

        //Task<User> IUserRepository.addUser(UserRegister user)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<UserRegister> IUserRepository.GetUserByEmailAndPassword(UserLoginDto userLoginDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<User> GetUserByEmailAndPassword(UserLoginDto userLoginDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
