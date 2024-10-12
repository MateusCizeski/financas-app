using financas_app.Aplication;
using financas_app.Data;
using financas_app.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace financas_app.Controllers
{
    [ApiController]
    [Route("api/Receive")]
    public class ReceiveController : ControllerBase
    {
        private readonly FinanceAppContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAplicReceive _aplicReceive;

        public ReceiveController(FinanceAppContext context, IConfiguration configuration, IAplicReceive aplicReceive)
        {
            _context = context;
            _configuration = configuration;
            _aplicReceive = aplicReceive;
        }

        [HttpPost]
        public IActionResult CreateReceive([FromBody] CreateReceiveDTO dto)
        {
            return null;
        }

        [HttpDelete]
        public IActionResult DeleteReceive([FromBody] DeleteReceiveDTO dto)
        {
            return null;
        }

        [HttpGet]
        public IActionResult ListReceives()
        { 
            try
            {
                var receives = _aplicReceive.ListReceives();
                return Ok(receives);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
