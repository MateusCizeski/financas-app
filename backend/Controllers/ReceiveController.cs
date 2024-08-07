using backend.Application.Receives;
using backend.Application.Receives.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/v1/receives")]
    public class ReceiveController : ControllerBase
    {
        private readonly IAplicReceives _aplicReceives;

        public ReceiveController(IAplicReceives aplicReceives)
        {
            _aplicReceives = aplicReceives;
        }

        [HttpPost]
        public IActionResult SaveReceive([FromBody] SaveReceiveDTO dto)
        {
            var receive = _aplicReceives.Save(dto);

            return Ok(receive);
        }

        [HttpGet]
        public IActionResult ListReceives(string userId, string date) 
        {
            var receives = _aplicReceives.List(userId, date);

            return Ok(receives);
        }
    }
}
