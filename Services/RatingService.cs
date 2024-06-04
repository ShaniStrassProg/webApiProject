using DTO;
using Entities;

//using Entities;

using Repositories;
using System.Data;
using Zxcvbn;
namespace Services
{
    public class RatingService : IRatingService

    {
        private IRatingRepository _ratingRepository;
       public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task addRating(Rating rating)
        {
            await _ratingRepository.addRating(rating);
        }
    }
}
