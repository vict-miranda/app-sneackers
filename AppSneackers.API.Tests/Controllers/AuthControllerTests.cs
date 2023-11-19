using AppSneackers.API.Controllers;
using AppSneackers.API.Mapping;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using Telerik.JustMock;

namespace AppSneackers.API.Tests.Controllers
{
    public class AuthControllerTests
    {
        AuthController _authController;
        IUserService _userService;
        IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:Key", "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx."}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            _userService = Mock.Create<IUserService>(Behavior.Strict);
            _authController = new AuthController(_configuration, _userService);
        }

        [Test]
        public async Task Login_OK()
        {
            //Arrange
            var userDto = new UserDto { Id = 1 };
            var authDto = new AuthorizationDto { Email = "asd@asd.cl", Password = "123456" };            

            Mock.Arrange(() => _userService.ValidateUserCredentials(authDto.Email, authDto.Password))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _authController.Login(authDto);
            var contentResult = result as OkObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.OK, contentResult.StatusCode);
        }

        [Test]
        public async Task Login_InvalidUserData_Error()
        {
            //Arrange
            var userDto = new UserDto { Id = 1 };
            var authDto = new AuthorizationDto();

            Mock.Arrange(() => _userService.ValidateUserCredentials(authDto.Email, authDto.Password))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _authController.Login(authDto);
            var contentResult = result as BadRequestResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<BadRequestResult>());
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }

        [Test]
        public async Task Login_UserDoesNotExists_Error()
        {
            //Arrange
            UserDto userDto = null;
            var authDto = new AuthorizationDto();

            Mock.Arrange(() => _userService.ValidateUserCredentials(authDto.Email, authDto.Password))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _authController.Login(authDto);
            var contentResult = result as BadRequestResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<BadRequestResult>());
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }

    }
}
