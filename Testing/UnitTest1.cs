using Repositories;

namespace Testing
{
    public class UserRepositoryIntegretionTest: IClassFixture<DatabaseFixture>
    {
        private readonly PhotoGalleryContext _dbContext;
        private readonly UserRepository _userRepository;
        
        public  UserRepositoryIntegretionTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbContext);

        }
        [Fact]
        public async Task GetUser_ValidCredentials_RetrnUser()
        {
            var email = "test@gmail.com";
            var password = "password";
        }
    }
}