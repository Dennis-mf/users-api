using users_api.DTOs;
using users_api.Models;

namespace users_api.Services;
public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers();

    Task<UserDto> GetUserById(int id);

    Task<UserDto> CreateUser(InsertUserDto user);

    Task<bool> UpdateUser(User user);

    Task<bool> DeleteUser(int id);
}
