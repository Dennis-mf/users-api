using users_api.Models;
namespace users_api.Data;

public class Repository
{
    public static List<People> People = new List<People>
    {
        new People(){
            Id = 1,
            Name = "Juan",
            BirthDate = new DateTime(1990, 3, 2)
        },
        new People(){
            Id = 2,
            Name = "Pedro",
            BirthDate = new DateTime(1991, 3, 2)
        },
        new People(){
            Id = 3,
            Name = "Pascal",
            BirthDate = new DateTime(1991, 3, 2)
        }
    };
}