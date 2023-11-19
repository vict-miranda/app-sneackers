using AppSneackers.API.Controllers;
using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services;
using AppSneackers.API.Services.Interfaces;
using AppSneackers.Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Telerik.JustMock;

namespace AppSneackers.API.Tests.Controllers
{
    public class UsersControllerTests
    {
        UsersController _usersController;
        IUserService _userService;
        int _userId;

        [SetUp]
        public void Setup()
        {
            _userId = 1;
            _userService = Mock.Create<IUserService>(Behavior.Strict);
            _usersController = new UsersController(_userService);
        }

        [Test]
        public async Task GetAll_OK()
        {
            //Arrange
            var userDto = new UserDto { };

            Mock.Arrange(() => _userService.GetSneackersByUserId(_userId))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.Get(_userId);
            var contentResult = result as OkObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.OK, contentResult.StatusCode);
        }

        [Test]
        public async Task GetSneackersFromUserFiltered_OK()
        {
            //Arrange
            var userDto = new API.Mapping.UserSneackersResponseDto { };
            var sneackerSearchDto = new SneackersSearchDto();

            Mock.Arrange(() => _userService.GetSneackersByUserId(sneackerSearchDto))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.GetSneackersByUserId(sneackerSearchDto);
            var contentResult = result as OkObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.OK, contentResult.StatusCode);
        }

        [Test]
        public async Task Post_CreateUser_OK()
        {
            //Arrange
            var userDto = new CreateUserDto { };
            var resultTuple = new ValueTuple<UserDto, ServiceResult>(new UserDto(), new ServiceResult());

            Mock.Arrange(() => _userService.CreateUser(userDto))
                .ReturnsAsync(resultTuple).OccursOnce();

            //Act
            var result = await _usersController.Post(userDto);
            var contentResult = result as OkObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.OK, contentResult.StatusCode);
        }

        [Test]
        public async Task Post_CreateUser_Error()
        {
            //Arrange
            var userDto = new CreateUserDto { };
            var resultTuple = new ValueTuple<UserDto, ServiceResult>(new UserDto(), new ServiceResult("Error"));

            Mock.Arrange(() => _userService.CreateUser(userDto))
                .ReturnsAsync(resultTuple).OccursOnce();

            //Act
            var result = await _usersController.Post(userDto);
            var contentResult = result as BadRequestObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.BadRequest, contentResult.StatusCode);
        }

        [Test]
        public async Task AddSneacker_OK()
        {
            //Arrange
            var userDto = new UserDto { };
            var sneackerDto = GetCreateSneackerDto();

            Mock.Arrange(() => _userService.AddSneacker(_userId, sneackerDto))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.AddSneacker(sneackerDto);
            var contentResult = result as OkObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.OK, contentResult.StatusCode);
        }

        [Test]
        public async Task AddSneacker_Error()
        {
            //Arrange
            UserDto userDto = null;
            var sneackerDto = GetCreateSneackerDto();

            Mock.Arrange(() => _userService.AddSneacker(_userId, sneackerDto))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.AddSneacker(sneackerDto);
            var contentResult = result as NotFoundObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.NotFound, contentResult.StatusCode);
        }

        [Test]
        public async Task UpdateSneacker_OK()
        {
            //Arrange
            var userDto = new UserDto { };
            var sneackerDto = GetUpdateSneackerDto();

            Mock.Arrange(() => _userService.UpdateSneacker(_userId, sneackerDto))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.UpdateSneacker(1, sneackerDto);
            var contentResult = result as OkObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.OK, contentResult.StatusCode);
        }

        [Test]
        public async Task UpdateSneacker_Error()
        {
            //Arrange
            UserDto userDto = null;
            var sneackerDto = GetUpdateSneackerDto();

            Mock.Arrange(() => _userService.UpdateSneacker(_userId, sneackerDto))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.UpdateSneacker(1, sneackerDto);
            var contentResult = result as NotFoundObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.NotFound, contentResult.StatusCode);
        }

        [Test]
        public async Task RemoveSneacker_OK()
        {
            //Arrange
            var userDto = new UserDto { };
            var sneackerDto = GetUpdateSneackerDto();

            Mock.Arrange(() => _userService.RemoveSneacker(_userId, 1))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.RemoveSneacker(_userId, 1);
            var contentResult = result as OkResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkResult>());
            Assert.AreEqual((int)HttpStatusCode.OK, contentResult.StatusCode);
        }

        [Test]
        public async Task RemoveSneacker_Error()
        {
            //Arrange
            UserDto userDto = null;
            var sneackerDto = GetUpdateSneackerDto();

            Mock.Arrange(() => _userService.RemoveSneacker(_userId, 1))
                .ReturnsAsync(userDto).OccursOnce();

            //Act
            var result = await _usersController.RemoveSneacker(_userId, 1);
            var contentResult = result as NotFoundObjectResult;

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(contentResult, Is.Not.Null);
            Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
            Assert.AreEqual((int)HttpStatusCode.NotFound, contentResult.StatusCode);
        }

        private CreateSneackerDto GetCreateSneackerDto()
        {
            return new CreateSneackerDto
            {
                UserId = _userId,
                Name = "",
                Brand = "",
                Price = 100,
                Size = 10,
                Year = 2023,
                Rate = 5
            };
        }

        private UpdateSneackerDto GetUpdateSneackerDto()
        {
            return new UpdateSneackerDto
            {
                UserId = _userId,
                Name = "",
                Brand = "",
                Price = 100,
                Size = 10,
                Year = 2023,
                Rate = 5
            };
        }

    }
}
