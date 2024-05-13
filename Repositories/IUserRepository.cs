﻿using DTO;
//using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> addUser(User user);
        Task<User> GetUserByEmailAndPassword(UserLoginDto userLoginDto);
        Task<User> getUserById(int id);
        Task<User> updateUser(int id, User userToUpdate);
    }
}