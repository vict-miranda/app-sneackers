using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services;
using AppSneackers.Domain.Entities;
using AppSneackers.Domain.Repositories;
using AutoMapper;
using Telerik.JustMock;

namespace AppSneackers.API.Tests.Services
{
    public class UserServiceTests
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        UserService _userService;

        [SetUp]
        public void Setup()
        {
            _userRepository = Mock.Create<IUserRepository>();

            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new SneackerProfile());
            });
            _mapper = mappingConfig.CreateMapper();

            _userService = new UserService(_userRepository, _mapper);
        }

        [Test]
        public async Task GetSneackersByUserId_OK()
        {
            //Arrange
            User entity = User.CreateNew(
                "Test",
                "Test",
                "test@test2.com",
                "123456");

            Mock.Arrange(() => _userRepository.GetUserById(1))
                .ReturnsAsync(entity).OccursOnce();

            //Act
            var result = await _userService.GetSneackersByUserId(1);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.IsTrue(result.Email.Equals("test@test2.com"));
        }

        [Test]
        public async Task CreateUser_OK()
        {
            //Arrange
            var createUserDto = new CreateUserDto { FirstName = "Test", LastName = "Test", Email = "test@test.com", Password = "123456" };
            User entity = User.CreateNew(
                "Test",
                "Test",
                "test@test2.com",
                "123456");

            List<User> users = new List<User>();
            users.Add(entity);

            Mock.Arrange(() => _userRepository.GetAll())
                .Returns(users.AsQueryable()).OccursOnce();

            //Act
            var (result, validation) = await _userService.CreateUser(createUserDto);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.IsTrue(result.Email.Equals("test@test.com"));
        }

        [Test]
        public async Task CreateUser_InvalidEmail_Error()
        {
            //Arrange
            var createUserDto = new CreateUserDto { FirstName = "Test", LastName = "Test", Email = "test@test.com", Password = "123456" };
            User entity = User.CreateNew(
                "Test",
                "Test",
                "test@test.com",
                "123456");

            List<User> users = new List<User>();
            users.Add(entity);

            Mock.Arrange(() => _userRepository.GetAll())
                .Returns(users.AsQueryable()).OccursOnce();

            //Act
            var (result, validation) = await _userService.CreateUser(createUserDto);

            //Assert
            Assert.That(result, Is.Null);
            Assert.That(validation, Is.Not.Null);
            Assert.IsTrue(validation.ErrorMessage.Equals("Email is already registered"));
        }

        [Test]
        public async Task CreateUser_ValidationFails_Error()
        {
            //Arrange
            var createUserDto = new CreateUserDto { FirstName = "", LastName = "", Email = "test@test.com", Password = "123456" };
            User entity = User.CreateNew("", "", "", "");

            List<User> users = new List<User>();
            users.Add(entity);

            Mock.Arrange(() => _userRepository.GetAll())
                .Returns(users.AsQueryable()).OccursOnce();

            //Act
            var (result, validation) = await _userService.CreateUser(createUserDto);

            //Assert
            Assert.That(result, Is.Null);
            Assert.That(validation, Is.Not.Null);
            Assert.IsTrue(((List<FluentValidation.Results.ValidationFailure>)validation.Data).Count > 0);
        }

        [Test]
        public async Task AddSneacker_OK()
        {
            //Arrange
            var createSneackerDto = GetCreateSneackerDto();
            User entity = User.CreateNew(
                "Test",
                "Test",
                "test@test2.com",
                "123456");

            Mock.Arrange(() => _userRepository.GetById(1))
                .ReturnsAsync(entity).OccursOnce();

            //Act
            var result = await _userService.AddSneacker(1, createSneackerDto);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.IsTrue(result.Sneackers.Count > 0);
        }

        [Test]
        public async Task AddSneacker_Error()
        {
            //Arrange
            var createSneackerDto = GetCreateSneackerDto();
            User entity = null;

            Mock.Arrange(() => _userRepository.GetById(1))
                .ReturnsAsync(entity).OccursOnce();

            //Act
            var result = await _userService.AddSneacker(1, createSneackerDto);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task UpdateSneacker_OK()
        {
            //Arrange
            var updateSneackerDto = GetUpdateSneackerDto();
            User entity = User.CreateNew(
                "Test",
                "Test",
                "test@test2.com",
                "123456");
            entity.AddSneacker("Jordan", "Nike", 100, 1, 1900, 1);

            Mock.Arrange(() => _userRepository.GetUserById(1))
                .ReturnsAsync(entity).OccursOnce();

            //Act
            var result = await _userService.UpdateSneacker(1, updateSneackerDto);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.IsTrue(result.Email.Equals("test@test2.com"));
            Assert.IsTrue(result.Sneackers.Count > 0);
        }

        [Test]
        public async Task UpdateSneacker_Error()
        {
            //Arrange
            var updateSneackerDto = GetUpdateSneackerDto();
            User entity = null;

            Mock.Arrange(() => _userRepository.GetUserById(1))
                .ReturnsAsync(entity).OccursOnce();

            //Act
            var result = await _userService.UpdateSneacker(1, updateSneackerDto);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task RemoveSneacker_OK()
        {
            //Arrange
            User entity = User.CreateNew(
                "Test",
                "Test",
                "test@test2.com",
                "123456");
            entity.AddSneacker("Jordan", "Nike", 100, 1, 1900, 1);

            Mock.Arrange(() => _userRepository.GetUserById(1))
                .ReturnsAsync(entity).OccursOnce();

            //Act
            var result = await _userService.RemoveSneacker(1, 1);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.IsTrue(result.Email.Equals("test@test2.com"));
            Assert.IsTrue(result.Sneackers.Count > 0);
        }

        [Test]
        public async Task RemoveSneacker_Error()
        {
            //Arrange
            User entity = null;

            Mock.Arrange(() => _userRepository.GetUserById(1))
                .ReturnsAsync(entity).OccursOnce();

            //Act
            var result = await _userService.RemoveSneacker(1, 1);

            //Assert
            Assert.That(result, Is.Null);
        }

        private CreateSneackerDto GetCreateSneackerDto()
        {
            return new CreateSneackerDto
            {
                UserId = 1,
                Name = "Nike Jordan",
                Brand = "Nike",
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
                UserId = 1,
                Name = "Nike Jordan",
                Brand = "Nike",
                Price = 100,
                Size = 10,
                Year = 2023,
                Rate = 5,
            };
        }

    }
}
