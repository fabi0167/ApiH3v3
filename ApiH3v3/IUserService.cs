using System.Threading.Tasks;

namespace ApiH3v3.Services
{
    public interface IUserService
    {
        Task<bool> ValidateCredentials(string username, string password);
    }
}
