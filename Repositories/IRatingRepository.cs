//using Entities;
using DTO;
using Entities;

namespace Repositories
{
    public interface IRatingRepository
    {

        Task addRating(Rating rating);
    }
}