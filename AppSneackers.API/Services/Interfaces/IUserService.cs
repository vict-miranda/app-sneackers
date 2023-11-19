using AppSneackers.API.Mapping;
using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.Domain.Common;

namespace AppSneackers.API.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Gets all sneackers from an user
        /// </summary>
        /// <param name="userId">User indentifier</param>
        /// <returns>An instance of <see cref="UserDto"/></returns>
        Task<UserDto> GetSneackersByUserId(int userId);

        /// <summary>
        /// Gets filtered sneackers from an user
        /// </summary>
        /// <param name="filter">Filters</param>
        /// <returns>An instance of <see cref="UserSneackersResponseDto"/></returns>
        Task<UserSneackersResponseDto> GetSneackersByUserId(SneackersSearchDto filter);

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

        /// <summary>
        /// Validates an user
        /// </summary>
        /// <param name="email">User Email</param>
        /// <param name="password">User Password</param>
        /// <returns>An instance of <see cref="UserDto"/></returns>
        Task<UserDto> ValidateUserCredentials(string email, string password);
    }
}
