
using Microsoft.AspNetCore.Mvc;
using users_api.DTOs;
using users_api.Models;

namespace users_api.Services;

public class UserService : IUserService
{
    private IUserDao _userDao;

    public UserService(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var results = await _userDao.GetUsers();
        return results.ToList();
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var result = await _userDao.GetUserById(id);
        return result;
    }

    public async Task<UserDto> CreateUser(InsertUserDto user)
    {
        var result = await _userDao.CreateUser(user);
        return result;
    }

    public async Task<bool> UpdateUser(User user)
    {
        var result = await _userDao.UpdateUser(user);
        return result;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var result = await _userDao.DeleteUser(id);
        return result;
    }
}