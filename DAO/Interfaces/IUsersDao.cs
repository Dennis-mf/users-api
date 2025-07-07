using users_api.DTOs;
using users_api.Models;

public interface IUserDao
{
    Task<IEnumerable<UserDto>> GetUsers();
    Task<UserDto> GetUserById(int id);
    Task<UserDto> CreateUser(InsertUserDto user);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(int id);
}