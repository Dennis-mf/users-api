using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using users_api.Models;
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

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var result = await _usersService.CreateUser(user);

            if(result)
            {
                return Created();
            }
            return BadRequest("No fue posible crear el usuario");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var result = await _usersService.UpdateUser(user);

            if (result)
            {
                return NoContent();
            }

            return Conflict();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _usersService.DeleteUser(id);
            if(result)
            {
                return NoContent();
            }

            return Conflict();
        }
    }
}
