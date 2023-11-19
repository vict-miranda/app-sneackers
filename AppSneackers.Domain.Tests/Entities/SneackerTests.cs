using AppSneackers.Domain.Entities;

namespace AppSneackers.Domain.Tests.Entities
{
    public class SneackerTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void CreateNewSneacker_OK()
        {
            Assert.DoesNotThrow(() => Sneacker.CreateNew(1, "Test", "Test", 1, 1, 1, 1));
        }

        [Test]
        public void CreateNewSneacker_ValidationError()
        {
            Assert.Throws<ArgumentException>(() => Sneacker.CreateNew(1, "", "Test", 1, 1, 1, 1));
        }

        [Test]
        public void UpdateSneacker_OK()
        {
            var s = Sneacker.CreateNew(1, "Test", "Test", 1, 1, 1, 1);

            Assert.DoesNotThrow(() => s.UpdateSneacker("Test", "Test", 1, 1, 1, 1));
        }

        [Test]
        public void UpdateSneacker_ValidationError()
        {
            var s = Sneacker.CreateNew(1, "Test", "Test", 1, 1, 1, 1);

            Assert.Throws<ArgumentException>(() => s.UpdateSneacker("", "", 1, 1, 1, 1));
        }
    }
}
