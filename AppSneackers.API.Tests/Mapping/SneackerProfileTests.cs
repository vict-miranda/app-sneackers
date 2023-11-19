using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.Domain.Entities;
using AutoMapper;

namespace AppSneackers.API.Tests.Mapping
{
    public class SneackerProfileTests
    {
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new SneackerProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Test]
        public void SourceToDestinationTest()
        {
            User source = User.CreateNew("test", "test", "asd@asd.com", "123123");
            source.AddSneacker("Nike Jordan 1", "Nike", 1, 1, 1, 1);

            var destination = _mapper.Map<SneackerDto>(source.Sneackers[0]);

            Assert.IsNotNull(destination);
            Assert.That(destination.Name, Is.EqualTo(source.Sneackers[0].Name));
            Assert.That(destination.Brand, Is.EqualTo(source.Sneackers[0].Brand));
            Assert.That(destination.Size, Is.EqualTo(source.Sneackers[0].Size));
            Assert.That(destination.Price, Is.EqualTo(source.Sneackers[0].Price));
            Assert.That(destination.Year, Is.EqualTo(source.Sneackers[0].Year));
            Assert.That(destination.Rate, Is.EqualTo(source.Sneackers[0].Rate));
        }

        [Test]
        public void DestinationToSourceTest()
        {
            SneackerDto source = new()
            {
                Name = "test",
                Brand =  "test",
                Size = 1,
                Price = 1,
                Year = 1,
                Rate = 1
            };

            var destination = _mapper.Map<Sneacker>(source);

            Assert.IsNotNull(destination);
            Assert.That(destination.Name, Is.EqualTo(source.Name));
            Assert.That(destination.Brand, Is.EqualTo(source.Brand));
            Assert.That(destination.Size, Is.EqualTo(source.Size));
            Assert.That(destination.Price, Is.EqualTo(source.Price));
            Assert.That(destination.Year, Is.EqualTo(source.Year));
            Assert.That(destination.Rate, Is.EqualTo(source.Rate));
        }
    }
}
