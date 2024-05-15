using DTO;
//using Entities;

using Repositories;
using System.Data;
using Zxcvbn;
namespace Services
{
    public class UserService : IUserService

    {
        private IUserRepository _userRepository;
       public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public async Task<UserRegister> getUserById(int id)
        //{
        //    return await _userRepository.getUserById(id);
        //}

        public async Task<User> addUser(User user)
        {

            if (evalutePassword(user.Password) < 2)
                return null;
            return await _userRepository.addUser(user);
        }
        public async Task<User> updateUser(int id, User userToUpdate)
        {
            if (evalutePassword(userToUpdate.Password) < 2)
                return null;
            return await _userRepository.updateUser(id, userToUpdate);
        }
        public int evalutePassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return (int)result.Score;
        }



        public Task<User> GetUserByEmailAndPassword(User userLogin)
        {
            return _userRepository.GetUserByEmailAndPassword(userLogin);
        }

        
    }
}
