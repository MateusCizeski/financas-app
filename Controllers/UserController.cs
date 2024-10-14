using financas_app.Aplication;
using financas_app.Data;
using financas_app.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace financas_app.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly FinanceAppContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAplicUser _aplicUser;

        public UserController(FinanceAppContext context, IConfiguration configuration, IAplicUser aplicUser)
        {
            _context = context;
            _configuration = configuration;
            _aplicUser = aplicUser;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO dto)
        {
            try
            {
                var user = _aplicUser.CreateUser(dto);

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        [HttpPost("login")]
        public IActionResult AuthUser([FromBody] AuthLoginDTO dto)
        {
            try
            {
                var user = _aplicUser.AuthUser(dto);

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult ListDetailUser([FromRoute] int id)
        {
            try
            {
                var user = _aplicUser.ListDetailUser(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        [HttpGet]
        public IActionResult ListUserBalance([FromQuery] ListUserBalanceDTO dto)
        {
            try
            {
                var items = _aplicUser.ListUserBalance(dto);

                return Ok(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }
    }
}
