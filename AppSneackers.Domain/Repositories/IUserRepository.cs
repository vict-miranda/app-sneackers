using AppSneackers.Domain.Entities;

namespace AppSneackers.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserById(int userId);
    }
}
