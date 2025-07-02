using users_api.Models;

public interface IUserDao
{
    Task<List<User>> GetUsers();
    Task<User> GetUserById(int id);
    Task<bool> CreateUser(User user);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(int id);
}