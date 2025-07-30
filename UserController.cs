using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Repositories;
using static UserManagement.Models.Login;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = _userRepository.Login(loginDto.Username, loginDto.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }

        }

        [HttpPost("Register")]
        public ActionResult Register(User user)
        {
            try
            {
                _userRepository.Register(user);
                return Ok($"Welcome {user.Name}");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("AllUsers")]
        public ActionResult<IEnumerable<User>> AllUsers()
        {
            var users = _userRepository.AllUsers();
            return Ok(users);
        }

        [HttpGet("GetUserId")]
        public ActionResult GetUserId(int id)
        {
            var user = _userRepository.GetUsersId(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpDelete("DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUsersId(id);
            if (user == null)
                return NotFound();

            _userRepository.DeleteUser(user);
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public ActionResult UpdateUser(int id,User user)
        {
            var existing = _userRepository.GetUsersId(id);
            if (existing == null)
                return NotFound();

            user.Id = id;
            _userRepository.UpdateUser(user);
            return Ok();
        }

    }
}
