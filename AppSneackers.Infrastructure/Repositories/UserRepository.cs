using AppSneackers.Domain.Entities;
using AppSneackers.Domain.Repositories;

namespace AppSneackers.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<User> GetUserById(int userId)
        {
            var respose = (await GetAsync(new CancellationToken(),
                        d => d.Id == userId,
                        includeProperties: "Sneackers")).FirstOrDefault();

            return respose;
        }
    }
}
