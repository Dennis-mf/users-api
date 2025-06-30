namespace users_api.Services;

using users_api.Models;

public interface IUserService
{
    bool Validate(People people);
}
