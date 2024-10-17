using financas_app.Aplication;
using financas_app.Data;
using financas_app.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace financas_app.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Receive")]
    public class ReceiveController : ControllerBase
    {
        private readonly IAplicReceive _aplicReceive;

        public ReceiveController(IAplicReceive aplicReceive)
        {
            _aplicReceive = aplicReceive;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateReceive([FromBody] CreateReceiveDTO dto)
        {
            var receive = _aplicReceive.CreateReceive(dto);
            return CreatedAtAction(nameof(CreateReceive), new { id = receive.Id }, receive);
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteReceive([FromRoute] int id)
        {
            _aplicReceive.DeleteReceive(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListReceives()
        {
            var receives = _aplicReceive.ListReceives();
            return Ok(receives);
        }
    }
}
