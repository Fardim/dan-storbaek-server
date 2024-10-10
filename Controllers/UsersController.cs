using dan_storbaek_server.Domains;
using dan_storbaek_server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dan_storbaek_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("[action]/{id:length(24)}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(User newUser)
        {
            await _userService.CreateAsync(newUser);

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpPut("[action]/{id:length(24)}")]
        public async Task<IActionResult> UpdateUser(string id, User updatedUser)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;

            var latestUser = await _userService.UpdateAsync(id, updatedUser);

            return Ok(latestUser);
        }

        [HttpDelete("[action]/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetUserById(id);

            if (user is null)
            {
                return NotFound();
            }

            await _userService.RemoveAsync(id);

            return NoContent();
        }
    
    }
}
