using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.Domain.Aggregates;
using AutoMapper;

namespace AppSneackers.API.Tests.Mapping
{
    public class UserProfileTests
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

            var destination = _mapper.Map<UserDto>(source);

            Assert.IsNotNull(destination);
            Assert.That(destination.Id, Is.EqualTo(source.Id));
            Assert.That(destination.FirstName, Is.EqualTo(source.FirstName));
            Assert.That(destination.LastName, Is.EqualTo(source.LastName));
        }

        [Test]
        public void DestinationToSourceTest()
        {
            UserDto source = new UserDto { Email = "asd@ad.com", FirstName = "test", LastName = "test" };

            var destination = _mapper.Map<User>(source);

            Assert.IsNotNull(destination);
            Assert.That(destination.Id, Is.EqualTo(source.Id));
            Assert.That(destination.FirstName, Is.EqualTo(source.FirstName));
            Assert.That(destination.LastName, Is.EqualTo(source.LastName));
        }

    }
}
