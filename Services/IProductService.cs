//using Entities;
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

        Task<Product> getProductById(int id);
        Task<List<Product>> getProducts(int position, int skip, string? desc, int? minPrice
            , int? maxPrice, int?[] categoryIds);

    }
}
