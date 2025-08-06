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

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _usersContext.Users.FindAsync(id);
        if(user == null)
        {
            return new UserDto
            {
                Id = 0,
                Name = "",
                Lastname = "",
                Email = "",
                Username = ""
            };
        }
        var UserDto = new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Lastname = user.Lastname,
            Email = user.Email,
            Username = user.Username
        };
        return UserDto;
    }

    public async Task<UserDto> CreateUser(InsertUserDto user)
    {
        var newUser = new User()
        {
            Name = user.Name,
            Lastname = user.Lastname,
            Email = user.Email,
            Username = user.Username
        };

        await _usersContext.Users.AddAsync(newUser);
        await _usersContext.SaveChangesAsync();

        return new UserDto
        {
            Id = newUser.Id,
            Name = newUser.Name,
            Lastname = newUser.Lastname,
            Email = newUser.Email,
            Username = newUser.Username
        };
    }


    public async Task<UserDto> UpdateUser(int id, UpdateUserDto user)
    {
        var updatedUser = await _usersContext.Users.FindAsync(id);

        if(updatedUser == null)
        {
            return new UserDto{};
        }

        updatedUser.Name = user.Name;
        updatedUser.Lastname = user.Lastname;
        updatedUser.Username = user.Username;
        updatedUser.Email = user.Email;

        await _usersContext.SaveChangesAsync();
        
        var userDto = new UserDto
        {
            Id = updatedUser.Id,
            Name = updatedUser.Name,
            Lastname = updatedUser.Lastname,
            Username = updatedUser.Username,
            Email = updatedUser.Email,
        };
        return userDto;
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