using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using users_api.Database;
using users_api.DTOs;
using users_api.Models;

namespace users_api.DAO;

public class UserDAO : IUserDao
{
    private readonly OracleDbService _dbService;
    private readonly UsersContext _usersContext;

    // public UserDAO(OracleDbService dbService)
    // {
    //     _dbService = dbService;
    // }

    public UserDAO(UsersContext context)
    {
        _usersContext = context;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await _usersContext.Users.Select(u => new UserDto {
            Id = u.Id,
            Name = u.Name,
            Lastname = u.Lastname,
            Email = u.Email,
            Username = u.Username,
        }).ToListAsync();

        return users;
    }

    public async Task<User> GetUserById(int id)
    {
        using var connection = _dbService.GetConnection();
        using var command = new OracleCommand("SELECT id, name, email FROM users WHERE id = :id" , connection);
        command.Parameters.Add(new OracleParameter("id", id));

        try{
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if(await reader.ReadAsync())
            {
                return new User()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                };
            }

            return null;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<bool> CreateUser(User user)
    {
        // using var connection = _dbService.GetConnection();
        // using var command = new OracleCommand(
        //     "INSERT INTO users (name, email) VALUES (:name, :email)", connection
        // );

        // command.BindByName = true;
        // command.Parameters.Add(new OracleParameter("name", user.Name));
        // command.Parameters.Add(new OracleParameter("email", user.Email));

        // await connection.OpenAsync();
        // int rowsAffected = await command.ExecuteNonQueryAsync();

        // return rowsAffected > 0;
        return true;
    }


    public async Task<bool> UpdateUser(User user)
    {
        // using var connection = _dbService.GetConnection();
        // using var command = new OracleCommand("UPDATE users SET name = :name, email = :email WHERE id = :id" , connection);
        // command.BindByName = true;
        // command.Parameters.Add(new OracleParameter("id", user.Id));
        // command.Parameters.Add(new OracleParameter("name", user.Name));
        // command.Parameters.Add(new OracleParameter("email", user.Email));

        // await connection.OpenAsync();
        // var rowsAffected = await command.ExecuteNonQueryAsync();

        // return rowsAffected > 0;
        return true;
    }

    //delete user

    public async Task<bool> DeleteUser(int id)
    {
        // using var connection = _dbService.GetConnection();
        // using var command = new OracleCommand("DELETE FROM users WHERE id = :id" , connection);
        // command.BindByName = true;
        // command.Parameters.Add(new OracleParameter("id", id));


        // await connection.OpenAsync();
        // var rowsAffected = await command.ExecuteNonQueryAsync();

        // return rowsAffected > 0;
        return true;
    }

}