using la_mia_pizzeria_static.Contexts;
using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Repositories
{
    public class DbPizzaRepo : IPizzaRepo
    {
        PizzaContext _ctx;
        public DbPizzaRepo(PizzaContext context) {
            _ctx = context;
        }
        public void CreatePizza(Pizza pizza, List<Ingredient> ingredients)
        {

        }

        public void DeletePizza(int id)
        {
            Pizza pizza = _ctx.Pizzas.Find(id);
            _ctx.Pizzas.Remove(pizza);
            _ctx.SaveChanges();
        }

        public List<Pizza> GetPizzas()
        {
            return _ctx.Pizzas.Include("Category").Include("Ingredients").ToList();
        }

        public Pizza GetPizzas(int id)
        {
            return _ctx.Pizzas.Include("Category").Include("Ingredients").Where(p => p.PizzaId == id ).FirstOrDefault();
        }

        public List<Pizza> GetPizzasByName(string name)
        {
            return _ctx.Pizzas.Include("Category").Include("Ingredients").Where(p => p.Name == name ).ToList();
        }

        public void UpdatePizza(Pizza pizza, List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }
    }
}
