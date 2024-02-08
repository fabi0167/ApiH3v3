using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiH3v3.Repositories;

namespace ApiH3v3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _userRepository.AddUser(user);
            
            return Ok(user);
        }
        // Add more controller actions for user-related operations
    }
}
