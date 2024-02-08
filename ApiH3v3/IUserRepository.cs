namespace ApiH3v3
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
    }
}
