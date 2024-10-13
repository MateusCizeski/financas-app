using financas_app.Aplication;
using financas_app.Data;
using financas_app.DTOs;
using financas_app.Models;
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
            try
            {
                var receive = _aplicReceive.CreateReceive(dto);

                return Ok(receive);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }

        [HttpDelete]
        public IActionResult DeleteReceive([FromBody] DeleteReceiveDTO dto)
        {
            try
            {
                _aplicReceive.DeleteReceive(dto);

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
