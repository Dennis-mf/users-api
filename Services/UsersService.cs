
using Microsoft.AspNetCore.Mvc;
using users_api.Models;

namespace users_api.Services;

public class UserService : IUserService
{
    public bool Validate(People people)
    {
        if(string.IsNullOrEmpty(people.Name))
        {
            return false;
        }

        return true;
    }
}