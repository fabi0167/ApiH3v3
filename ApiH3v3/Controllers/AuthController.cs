using Microsoft.AspNetCore.Mvc;
using ApiH3v3.Services;

namespace ApiH3v3.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
           // Validate username and password;
              var isAuthenticated = await _userService.ValidateCredentials(user.Username, user.Password);
              if (!isAuthenticated)
              {
                  return Unauthorized(); // Return 401 Unauthorized if credentials are invalid
              }

              // Authentication successful
              return Ok(isAuthenticated); // Return 200 OK or another response indicating successful authentication
            
            
        }
    }
}
