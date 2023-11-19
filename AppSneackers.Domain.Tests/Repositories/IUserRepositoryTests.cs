using AppSneackers.Domain.Aggregates;
using AppSneackers.Domain.Repositories;
using Telerik.JustMock;

namespace AppSneackers.Domain.Tests.Repositories
{
    public class IUserRepositoryTests
    {
        IUserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = Mock.Create<IUserRepository>();
        }

        [Test]
        public async Task Get_OK()
        {
            //Arrange
            User entity = User.CreateNew("Test", "Test", "test@test.com" , "123456");

             try
            {
                await _userRepository.Create(entity);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public async Task GetAsync_OK()
        {
            try
            {
                await _userRepository.GetAsync(CancellationToken.None);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public async Task Create_OK()
        {
            User entity = User.CreateNew("Test", "Test", "test@test.com", "123456");

            try
            {
                await _userRepository.Create(entity);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public async Task Update_OK()
        {
            User entity = User.CreateNew("Test", "Test", "test@test.com", "123456");

            try
            {
                await _userRepository.Update(1, entity);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public async Task Delete_OK()
        {
            try
            {
                await _userRepository.Delete(1);
                return; // indicates success
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
