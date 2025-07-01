using Oracle.ManagedDataAccess.Client;
using users_api.Database;
using users_api.Models;

namespace users_api.DAO;

public class UserDAO : IUserDao
{
    private readonly OracleDbService _dbService;

    public UserDAO(OracleDbService dbService)
    {
        _dbService = dbService;
    }

    public async Task<List<User>> GetUsers()
    {
        using var connection = _dbService.GetConnection();
        var users = new List<User>();

        using var command = new OracleCommand("SELECT id, name, email FROM users" , connection);

        try{
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var user = new User(){
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                };

                users.Add(user);
            }
        }
        catch (Exception ex)
        {
            throw;
        }

        return users;
    }

    //get user by id

    //get all users

    //update user

    //delete user


}