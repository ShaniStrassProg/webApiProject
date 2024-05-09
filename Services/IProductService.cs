using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<Product> addProduct(Product product);
        int evalutePassword(string password);
        Task<User> GetUserByEmailAndPassword(UserLogin userLogin);
        Task<User> getUserById(int id);
        Task<User> updateUser(int id, User userToUpdate);
    }
}
