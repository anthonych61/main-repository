using Moq;
using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using Novus_Catalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace NovusCatalogTests
{
    [TestClass]
    public class LoginServiceTest
    {
        private Mock<IUserRepository> _userRepository;
        private UserService _userService;
        private Users _user;

        [TestInitialize]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
            _user = new Users("Administrator", "admin");
        }

        [TestMethod]
        public void TestLoginSuccess()
        {
            // arrange
            _userRepository.Setup(r => r.CheckUserPassword("Administrator", "admin")).Returns(true);

            // act
            bool loginResult = _userService.UserExistsByAccountAndPassword("Administrator", "admin");

            // assert
            Assert.IsTrue(loginResult, "Login should be successful with valid credentials.");
        }

        [TestMethod]
        public void TestLoginFailure_InvalidCredentials()
        {
            _userRepository.Setup(r => r.CheckUserPassword("Administrator", "test1234")).Returns(false);

            bool loginResult = _userService.UserExistsByAccountAndPassword("Administrator", "test1234");

            Assert.IsFalse(loginResult, "Login should fail with invalid credentials.");
        }

        [TestMethod]
        public void ChangePassword_ValidUserAndPassword_PasswordChanged()
        {
            string username = "Administrator";
            string oldPassword = "admin";
            string newPassword = "password123";

            // mock findByAccount to return the user
            _userRepository.Setup(r => r.FindByAccount(username)).Returns(_user);

            _userService.FindByAccount(username);

            // change password
            _userService.ChangeUserPassword(_user, username, oldPassword, newPassword);

            // verify that findByAccount was called once
            _userRepository.Verify(r => r.FindByAccount(username), Times.Once);

            // verify that CheckUserPassword was called once with the user whose password was updated
            _userRepository.Verify(r => r.CheckUserPassword(username, oldPassword, newPassword), Times.Once);

            // assert that user's password is updated
            Assert.AreEqual(newPassword, _user.password);
        }
    }
}
