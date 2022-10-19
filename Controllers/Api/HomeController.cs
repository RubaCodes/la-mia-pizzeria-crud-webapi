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
        public IActionResult Get(string? name)
        {
            List<Pizza> menu;
            if (name != null)
            {
                menu = _ctx.Pizzas.Where(p => p.Name.ToLower().Contains(name.ToLower())).Include("Category").Include("Ingredients").ToList();
            }
            else
            {
                menu = _ctx.Pizzas.Include("Category").Include("Ingredients").ToList();
            }
            return Ok(menu);
        }
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            Pizza pizza = _ctx.Pizzas.Include("Category").Include("Ingredients").Where(p => p.PizzaId == id).FirstOrDefault();
            return Ok(pizza);
        }
        //get ma di Pizzacategories per l'update
        [HttpGet("{id}")]
        public IActionResult Ext(int id)
        {   
            categoryPizzas cp = new categoryPizzas();
            cp.Pizza = _ctx.Pizzas.Include("Category").Include("Ingredients").Where(p => p.PizzaId == id).FirstOrDefault();
            cp.Categories = _ctx.Categories.ToList();
            cp.Ingredients = _ctx.Ingredients.ToList();
            return Ok(cp);
        }

        [HttpPut]
        public IActionResult Update(int id, categoryPizzas model) {

            
            //prendo la pizza dal bd con i suoi ingredienti
            //Pizza pizza = _ctx.Pizzas.Where(x => x.PizzaId == model.Pizza.PizzaId).Include("Ingredients").First();
            //if (pizza == null)
            //{
            //    return NotFound("La pizza che stai cercando di modificare non esiste");
            //}
            //fetch nuovi ingredienti dal db
           // model.Pizza.Ingredients = _ctx.Ingredients.Where(x => model.SelectedIngredients.Contains(x.Id)).ToList();
            //riassegnazioni
            //pizza.Name = model.Pizza.Name;
            //pizza.Description = model.Pizza.Description;
            //pizza.Price = model.Pizza.Price;
            //pizza.ImgPath = model.Pizza.ImgPath;
            //pizza.CategoryId = model.Pizza.CategoryId;
           // pizza.Ingredients = model.Pizza.Ingredients;
            //_ctx.SaveChanges();
            return Ok();
            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            Pizza pizza =_ctx.Pizzas.Find(id);
            if (pizza == null) {
                return NotFound("la pizza che stai cercando di eliminare non esite");
            }
            _ctx.Pizzas.Remove(pizza);
            //_ctx.SaveChanges();
            return Ok("Pizza eliminata correttamente");

        }
    }
}
