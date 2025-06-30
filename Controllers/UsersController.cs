using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace users_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople()
        {
            return Repository.People;
        }

        [HttpGet("{id}")]
        public ActionResult<People> GetUser(int id)
        {
            var user = Repository.People.FirstOrDefault(n => n.Id == id);

            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
            
            
        }

        [HttpGet("search/{name}")]
        public ActionResult<People> GetUserByName(string name)
        {
            try{
                return Ok(Repository.People.Where(u => u.Name.ToLower().Contains(name.ToLower())).ToList());
            } catch(Exception e)
            {
                return NotFound("User not found" + e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(People user)
        {
            if(string.IsNullOrEmpty(user.Name))
            {
                return BadRequest();
            }

            Repository.People.Add(user);

            return NoContent();
        }

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
                }
            };
        }


        public class People
        {
            public int Id {get; set;}
            public required string Name {get; set;}
            public DateTime BirthDate {get; set;}
        }
    }
}
