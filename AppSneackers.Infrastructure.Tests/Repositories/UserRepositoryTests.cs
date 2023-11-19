using AppSneackers.Infrastructure.Repositories;
using System;

namespace AppSneackers.Infrastructure.Tests.Repositories
{
    public class UserRepositoryTests
    {
        UserRepository userRepository;
        AppDbContext appDbContext;

        [SetUp]
        public void Setup()
        {
            //appDbContext = new AppDbContext();
            //userRepository = new UserRepository();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
