using ApiH3v3.Repositories;
using System.Threading.Tasks;

namespace ApiH3v3.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            // Retrieve user by username from the database
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return false; // User not found
            }

            // Check if the provided password matches the user's password
            var result = user.Password == password;

            return result;
        }
    }
}
