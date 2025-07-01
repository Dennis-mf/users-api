using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using users_api.Models;
using users_api.Data;
using users_api.Services;

namespace users_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _usersService;

        public UsersController(IUserService userService)
        {
            _usersService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetPeople()
        {
            var result = await _usersService.GetUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _usersService.GetUserById(id);

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
            if(!_usersService.Validate(user))
            {
                return BadRequest();
            }

            Repository.People.Add(user);

            return NoContent();
        }
    }
}
