namespace users_api.Models;

public class People
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public DateTime BirthDate {get; set;}
}