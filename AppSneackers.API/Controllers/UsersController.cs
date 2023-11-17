using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppSneackers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all sneackers from an user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var response = await _userService.GetSneackersByUserId(userId);
            return Ok(response.Sneackers);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDto user)
        {
            var response = await _userService.CreateUser(user);
            return Ok(response);
        }

        /// <summary>
        /// Add a sneacker to an user
        /// </summary>
        /// <param name="sneacker">Sneacker information</param>
        /// <returns></returns>
        [HttpPost("AddSneacker")]
        public async Task<IActionResult> AddSneacker(CreateSneackerDto sneacker)
        {
            var response = await _userService.AddSneacker(sneacker.UserId, sneacker);
            return Ok(response);
        }

        /// <summary>
        /// Updates a sneacker
        /// </summary>
        /// <param name="sneackerId">Sneacker identifier</param>
        /// <param name="sneacker">Sneacker information</param>
        /// <returns></returns>
        [HttpPut("UpdateSneacker/{sneackerId}")]
        public async Task<IActionResult> UpdateSneacker(int sneackerId, UpdateSneackerDto sneacker)
        {
            var response = await _userService.UpdateSneacker(sneackerId, sneacker);
            return Ok(response);
        }

        /// <summary>
        /// Removes a sneacker
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="sneackerId">Sneacker identifier</param>
        /// <returns></returns>
        [HttpDelete("RemoveSneacker/{userId}/{sneackerId}")]
        public async Task<IActionResult> RemoveSneacker(int userId, int sneackerId)
        {
            var response = await _userService.RemoveSneacker(userId, sneackerId);
            return Ok(response);
        }

    }
}
