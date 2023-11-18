using AppSneackers.API.Mapping.Sneacker;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppSneackers.API.Controllers
{
    [Authorize]
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
        /// <response code="200">Gets successfully.</response>
        /// <response code="401">Not authorized.</response>
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
        /// <response code="200">Created successfully.</response>
        /// <response code="400">Bad Request.</response>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserDto user)
        {
            var (response, serviceResult) = await _userService.CreateUser(user);
            if (serviceResult != null && (serviceResult.Data != null || serviceResult.ErrorMessage != null))
            {
                return BadRequest(serviceResult.Data != null ? serviceResult.Data : serviceResult.ErrorMessage);
            }
            return Ok(response);
        }

        /// <summary>
        /// Add a sneacker to an user
        /// </summary>
        /// <param name="sneacker">Sneacker information</param>
        /// <returns></returns>
        /// <response code="200">Added successfully.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="500">Bad Request.</response>
        [HttpPost("AddSneacker")]
        public async Task<IActionResult> AddSneacker(CreateSneackerDto sneacker)
        {
            var response = await _userService.AddSneacker(sneacker.UserId, sneacker);
            if (response == null)
            {
                return NotFound("User not found");
            }
            return Ok(response.Sneackers);
        }

        /// <summary>
        /// Updates a sneacker
        /// </summary>
        /// <param name="sneackerId">Sneacker identifier</param>
        /// <param name="sneacker">Sneacker information</param>
        /// <returns></returns>
        /// <response code="200">Updated successfully.</response>
        /// <response code="404">Not Found.</response>
        /// <response code="500">Bad Request.</response>
        [HttpPut("UpdateSneacker/{sneackerId}")]
        public async Task<IActionResult> UpdateSneacker(int sneackerId, UpdateSneackerDto sneacker)
        {
            var response = await _userService.UpdateSneacker(sneackerId, sneacker);
            if (response == null)
            {
                return NotFound("User not found");
            }
            return Ok(response.Sneackers);
        }

        /// <summary>
        /// Removes a sneacker
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <param name="sneackerId">Sneacker identifier</param>
        /// <returns></returns>
        /// <response code="200">Deleted successfully.</response>
        /// <response code="404">Not Found.</response>
        [HttpDelete("RemoveSneacker/{userId}/{sneackerId}")]
        public async Task<IActionResult> RemoveSneacker(int userId, int sneackerId)
        {
            var response = await _userService.RemoveSneacker(userId, sneackerId);
            if (response == null)
            {
                return NotFound("User not found");
            }
            return Ok();
        }

    }
}
