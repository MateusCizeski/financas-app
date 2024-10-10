using financas_app.Data;
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
    }
}
