using Azure;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Testing
{
    public class UserRepositoryUnit
    {
        [Fact]
        // login happy
        public async Task GetUser_ValidCredentials_ReturnUser() 
        {
            var user = new User { Email = "test@example.com", Password = "password" };

            var mockContex = new Mock<PhotoGalleryContext>();
            var users = new List<User>() { user };
            mockContex.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContex.Object);

            var result = await userRepository.GetUserByEmailAndPassword(user);

            Assert.Equal(user, result);


        }
        [Fact]
        // login unhappy email not exit
        public async Task GetUser_EmailNoExist_ReturnUser()
        {
            var user = new User { Email = "test@example.com", Password = "password" };
            var userNotEqual = new User { Email = "t@example.com", Password = "password" };

            var mockContex = new Mock<PhotoGalleryContext>();
            var users = new List<User>() { user };
            mockContex.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContex.Object);

            var result = await userRepository.GetUserByEmailAndPassword(userNotEqual);

            Assert.Null(result);


        }


        [Fact]
        // update happy
        public async Task UpdateUser_ValidUser_UpdateUserDetails()
        {
            // Arrange
            var id = 1;
            var userToUpdate = new User { Email = "testUpdated@gmail.com", FirstName = "UpdatedFirstName", LastName = "UpdatedLastName" };
            var mockContext = new Mock<PhotoGalleryContext>();
            var mockDbSet = new Mock<DbSet<User>>();

            mockDbSet.Setup(m => m.Update(It.IsAny<User>())).Callback<User>(u =>
            {
                u.UserId = id;
            });

            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);
            mockContext.Setup(x => x.Update(It.IsAny<User>())).Callback<User>(u =>
            {
                u.UserId = id;
            });
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

            var userRepository = new UserRepository(mockContext.Object);

            // Act
            var result = await userRepository.updateUser(id, userToUpdate);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.UserId);
            Assert.Equal("testUpdated@gmail.com", result.Email);
            Assert.Equal("UpdatedFirstName", result.FirstName);
            Assert.Equal("UpdatedLastName", result.LastName);
        }



        [Fact]
        // register happy
        public async Task AddUser_ValidUser_ReturnsAddedUser()
        {
            // Arrange
            var user = new User { Email = "test@example.com", Password = "password", FirstName = "First", LastName = "Last" };

            var mockContext = new Mock<PhotoGalleryContext>();
            var users = new List<User>();
            var mockDbSet = new Mock<DbSet<User>>();

            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.AsQueryable().Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.AsQueryable().Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.AsQueryable().ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.AsQueryable().GetEnumerator());

            mockDbSet.Setup(d => d.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
                .Callback<User, CancellationToken>((u, ct) => users.Add(u))
                .ReturnsAsync((User u, CancellationToken ct) => (EntityEntry<User>)null);

            mockContext.Setup(x => x.Users).Returns(mockDbSet.Object);
            mockContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var userRepository = new UserRepository(mockContext.Object);

            // Act
            var result = await userRepository.addUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("test@example.com", result.Email);
            Assert.Equal("password", result.Password);
            Assert.Equal("First", result.FirstName);
            Assert.Equal("Last", result.LastName);
        }
    }



}

