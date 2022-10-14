using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static;
using la_mia_pizzeria_static.Contexts;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        PizzaContext _ctx;
        public HomeController()
        {
            _ctx = new PizzaContext();
        }


        [HttpGet]
        public IActionResult Get() {
            List<Pizza> menu = _ctx.Pizzas.ToList();
            return Ok(menu);
        }
    }
}
