using users_api.Models;

namespace users_api.Services;
public interface IUserService
{
    bool Validate(People people);
}
