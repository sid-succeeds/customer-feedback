using NUnit.Framework;
using FluentAssertions;
using cfms_web_api.Controllers.v2;
using cfms_web_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using cfms_web_api.Models;

namespace cfms_web_api_tests.Controllers.v2
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _userController;
        private Mock<IUserService> _userServiceMock;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserService>();
            _userController = new UserController(_userServiceMock.Object);
        }

        [Test]
        public void GetAllUsers_Returns_All_Users()
        {
            // Arrange
            var users = new List<User>
            {
                new User("1", "John Doe", "john@example.com", "password", "someOtherValue"),
                new User("2", "Jane Smith", "jane@example.com", "password", "someOtherValue")
            };
            _userServiceMock.Setup(service => service.GetAllUsers()).Returns(users);

            // Act
            var result = _userController.GetAllUsers();

            // Assert
            result.Should().BeOfType<ActionResult<List<User>>>();
            result.Value.Should().BeEquivalentTo(users);
        }

        [Test]
        public void GetUser_Returns_User_By_Email_And_Password_Combination()
        {
            // Arrange
            var user = new User("1", "John Doe", "john@example.com", "password", "someOtherValue");
            _userServiceMock.Setup(service => service.GetUser("john@example.com", "password")).Returns(user);

            // Act
            var result = _userController.GetUser("john@example.com", "password");

            // Assert
            result.Should().BeOfType<ActionResult<User>>();
            result.Value.Should().BeEquivalentTo(user);
        }

        [Test]
        public void AddUser_Adds_New_User()
        {
            // Arrange
            var newUser = new User("3", "Bukayo", "Saka", "bukayo@company.com", "password");
            _userServiceMock.Setup(service => service.AddUser(newUser)).Returns(new List<User> { newUser });

            // Act
            var result = _userController.AddUser(newUser);

            // Assert
            result.Should().BeOfType<ActionResult<List<User>>>();
            result.Value.Should().ContainEquivalentOf(newUser);
        }

        [Test]
        public void DeleteUser_Deletes_User_By_Id()
        {
            // Arrange
            var userId = "1";
            var usersWithoutDeletedUser = new List<User>
            {
                new User ("2", "Jane", "Smith","jane@example.com", "")
            };
            _userServiceMock.Setup(service => service.DeleteUserById(userId)).Returns(usersWithoutDeletedUser);

            // Act
            var result = _userController.DeleteUser(userId);

            // Assert
            result.Should().BeOfType<ActionResult<List<User>>>();
            result.Value.Should().BeEquivalentTo(usersWithoutDeletedUser);
        }

        [Test]
        public void DeleteUser_Returns_NotFound_If_User_Not_Found()
        {
            // Arrange
            var userId = "10";
            _userServiceMock.Setup(service => service.DeleteUserById(userId)).Returns((List<User>)null);

            // Act
            var result = _userController.DeleteUser(userId);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
