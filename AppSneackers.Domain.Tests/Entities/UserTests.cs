using AppSneackers.Domain.Aggregates;

namespace AppSneackers.Domain.Tests.Entities
{
    public class UserTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CreateNewUser_OK()
        {
            Assert.DoesNotThrow(() => User.CreateNew("Test", "Test", "asd@asd.cl", "123123"));
        }

        [Test]
        public void UpdateSneacker_OK()
        {
            var user = User.CreateNew("Test", "Test", "asd@asd.cl", "123123");
            Assert.DoesNotThrow(() => user.UpdateSneacker(1, "Test", "Test", 1, 1, 1, 1));
        }

        [Test]
        public void RemoveSneacker_OK()
        {
            var user = User.CreateNew("Test", "Test", "asd@asd.cl", "123123");
            Assert.DoesNotThrow(() => user.RemoveSneacker(1));
        }

    }
}
