using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_static;
using la_mia_pizzeria_static.Contexts;
using la_mia_pizzeria_static.Models;
using NuGet.Protocol;

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
            var  menu = _ctx.Pizzas.Include("Category").Include("Ingredients").ToList();
            return Ok(menu);
        }
    }
}
