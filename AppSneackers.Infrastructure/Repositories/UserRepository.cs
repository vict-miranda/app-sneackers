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
    }
}
