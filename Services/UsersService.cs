
using Microsoft.AspNetCore.Mvc;
using users_api.Models;

namespace users_api.Services;

public class UserService : IUserService
{
    private IUserDao _userDao;

    public UserService(IUserDao userDao)
    {
        _userDao = userDao;
    }

    public bool Validate(People people)
    {
        if(string.IsNullOrEmpty(people.Name))
        {
            return false;
        }

        return true;
    }

    public async Task<List<User>> GetUsers()
    {
        var results = await _userDao.GetUsers();
        return results.ToList();
    }

    public async Task<User> GetUserById(int id)
    {
        var result = await _userDao.GetUserById(id);
        return result;
    }
}