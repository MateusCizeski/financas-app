using backend.Application.Users;
using backend.Application.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IAplicUsers _aplicUsers;

        public UsersController(IAplicUsers aplicUsers)
        {
            _aplicUsers = aplicUsers;
        }

        [HttpPost]
        public IActionResult SaveUser(SaveUserDTO dto)
        {
            var user = _aplicUsers.Save(dto);

            return Ok(user);
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult ListUser(int id)
        {
            var user = _aplicUsers.ListUser(id);

            return Ok(user);
        }
    }
}
