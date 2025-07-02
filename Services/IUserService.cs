using users_api.Models;

namespace users_api.Services;
public interface IUserService
{
    bool Validate(People people);

    Task<List<User>> GetUsers();

    Task<User> GetUserById(int id);

    Task<bool> CreateUser(User user);

    Task<bool> UpdateUser(User user);

    Task<bool> DeleteUser(int id);
}
