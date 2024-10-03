using financas_app.Data;
using Microsoft.AspNetCore.Mvc;

namespace financas_app.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly FinanceAppContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(FinanceAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
    }
}
