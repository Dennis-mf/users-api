namespace users_api.DTOs;

public class InsertUserDto
{
    public required string Name {get; set;} = "";

    public required string Email {get; set;} = "";

    public string Username { get; set; } = "";

    public string Lastname { get; set; } = "";
}
