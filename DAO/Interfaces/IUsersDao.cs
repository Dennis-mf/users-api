using users_api.Models;

public interface IUserDao
{
    Task<List<User>> GetUsers();
}