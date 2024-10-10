using financas_app.Data;
using Microsoft.AspNetCore.Mvc;

namespace financas_app.Controllers
{
    [ApiController]
    [Route("api/Receive")]
    public class ReceiveController : ControllerBase
    {
        private readonly FinanceAppContext _context;
        private readonly IConfiguration _configuration;

        public ReceiveController(FinanceAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
    }
}
