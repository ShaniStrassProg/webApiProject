using Microsoft.EntityFrameworkCore;
using Repositories;
using Xunit;

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
        // login happy
        public async Task GetUser_ValidCredentials_ReturnUser()
        {
            var email = "test@gmail.com";
            var password = "password";
            var user = new User { Email = email, Password = password, FirstName = "test", LastName = "test22" };
            var userLogin = new User { Email = email, Password = password, FirstName = null, LastName = null };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            var result = await _userRepository.GetUserByEmailAndPassword(userLogin);
            Assert.NotNull(result);
        }

        [Fact]
        //register happy
        public async Task AddUser_ValidUser_ReturnsAddedUser()
        {
            // Arrange
            var newUser = new User { Email = "newuser@example.com", Password = "password", FirstName = "New", LastName = "User" };

            // Act
            var result = await _userRepository.addUser(newUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("newuser@example.com", result.Email);
            Assert.Equal("password", result.Password);
            Assert.Equal("New", result.FirstName);
            Assert.Equal("User", result.LastName);

            // Verify that the user was actually added to the database
            var addedUser = await _dbContext.Users.FindAsync(result.UserId);
            Assert.NotNull(addedUser);
            Assert.Equal("newuser@example.com", addedUser.Email);
            Assert.Equal("password", addedUser.Password);
            Assert.Equal("New", addedUser.FirstName);
            Assert.Equal("User", addedUser.LastName);
        }


        
        [Fact]
        // update happy without name
        public async Task updateUser_ValidIdAndUserWithOutName_ReturnsUpdatedUser()
        {
            // Arrange
            var existingUser = new User { Email = "existing@example.com", Password = "password" };
            await _dbContext.Users.AddAsync(existingUser);
            await _dbContext.SaveChangesAsync();

            // Detach existing entity to avoid tracking issues
            _dbContext.Entry(existingUser).State = EntityState.Detached;

            var userToUpdate = new User { Email = "updated@example.com", Password = "newpassword" };

            // Act
            var result = await _userRepository.updateUser(existingUser.UserId, userToUpdate);

            // Assert
            Assert.Equal(existingUser.UserId, result.UserId);
            Assert.Equal("updated@example.com", result.Email);
            Assert.Equal("newpassword", result.Password);
        }

        [Fact]
        //update happy 
        public async Task updateUser_ValidIdAndUser_ReturnsUpdatedUser()
        {
            // Arrange
            var existingUser = new User
            {
                Email = "existing@example.com",
                Password = "password",
                FirstName = "ExistingFN", // Shorter first name
                LastName = "ExistingLN"   // Shorter last name
            };
            await _dbContext.Users.AddAsync(existingUser);
            await _dbContext.SaveChangesAsync();

            // Detach existing entity to avoid tracking issues
            _dbContext.Entry(existingUser).State = EntityState.Detached;

            var userToUpdate = new User
            {
                Email = "updated@example.com",
                Password = "newpassword",
                FirstName = "UpdatedFN", // Shorter first name
                LastName = "UpdatedLN"   // Shorter last name
            };

            // Act
            var result = await _userRepository.updateUser(existingUser.UserId, userToUpdate);

            // Assert
            Assert.Equal(existingUser.UserId, result.UserId);
            Assert.Equal("updated@example.com", result.Email);
            Assert.Equal("newpassword", result.Password);
            Assert.Equal("UpdatedFN", result.FirstName);
            Assert.Equal("UpdatedLN", result.LastName);
        }
    }
}
