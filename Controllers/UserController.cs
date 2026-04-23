using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();

        // GET
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        // POST
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                return BadRequest("Invalid data");

            user.Id = users.Count + 1;
            users.Add(user);

            return Ok(user);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return Ok(user);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null) return NotFound();

            users.Remove(user);
            return Ok("Deleted");
        }
    }
}