using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal interface ICategoryService
    {
        Task<Category> addCategory(Category category);
        Task<Category> GetCategoryById(int id);
        Task<Category> updateCategory(int id, Category category);
    }
}
