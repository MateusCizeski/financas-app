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

        public UserController(FinanceAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO dto)
        {
            return null;
        }

        [HttpPost]
        public IActionResult AuthUser([FromBody] AuthLoginDTO dto)
        {
            return null;
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult ListDetailUser([FromRoute] int id)
        {
            return null;
        }

        [HttpGet]
        public IActionResult ListUserBalance([FromBody] ListUserBalanceDTO dto)
        {
            return null;
        }
    }
}
