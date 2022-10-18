using la_mia_pizzeria_static.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers.Api
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        PizzaContext _ctx;
        public MessageController() {
            _ctx = new PizzaContext();
        }
        [HttpPost]
        public IActionResult Send([FromBody] Message msg) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            _ctx.Messages.Add(msg);
            _ctx.SaveChanges();
            return Ok("Messaggio inviato");
        }
    }
}
