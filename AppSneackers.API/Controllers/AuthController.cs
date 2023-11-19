using AppSneackers.API.Mapping;
using AppSneackers.API.Mapping.User;
using AppSneackers.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppSneackers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config, IUserService userService)
        {
            _configuration = config ?? throw new ArgumentNullException(nameof(config));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="_userData"></param>
        /// <returns></returns>
        /// <response code="200">Logued successfully.</response>
        /// <response code="400">Bad Request.</response>

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthorizationDto _userData)
        {
            if (_userData != null && !string.IsNullOrEmpty(_userData.Email) && !string.IsNullOrEmpty(_userData.Password))
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }

            
        }

        private async Task<UserDto> GetUser(string email, string password)
        {
            return await _userService.ValidateUserCredentials(email, password);
        }
    }
}
