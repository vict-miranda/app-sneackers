using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;

namespace AppSneackers.API.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Gets all sneackers from an user
        /// </summary>
        /// <param name="userId">user indentifier</param>
        /// <returns>An instance of <see cref="UserDto"/></returns>
        Task<UserDto> GetSneackersByUserId(int userId);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="userDto">User information</param>
        /// <returns>An instance of <see cref="UserDto"/></returns>
        Task<(UserDto, ServiceResult)> CreateUser(CreateUserDto userDto);

        /// <summary>
        /// Add a sneacker to an user
        /// </summary>
        /// <param name="userId">User indenfier</param>
        /// <param name="snickerDto">Sneacker information</param>
        /// <returns>An instance of <see cref="UserDto"/></returns>
        Task<UserDto> AddSneacker(int userId, CreateSneackerDto snickerDto);

        /// <summary>
        /// Updates a sneacker
        /// </summary>
        /// <param name="sneackerId">Sneacker indenfier</param>
        /// <param name="snickerDto">Sneacker information</param>
        /// <returns>An instance of <see cref="UserDto"/></returns>
        Task<UserDto> UpdateSneacker(int sneackerId, UpdateSneackerDto snickerDto);

        /// <summary>
        /// Remove a sneacker
        /// </summary>
        /// <param name="userId">User indenfier</param>
        /// <param name="sneackerId">Sneacker indenfier</param>
        /// <returns>An instance of <see cref="UserDto"/></returns>
        Task<UserDto> RemoveSneacker(int userId, int sneackerId);
    }
}
