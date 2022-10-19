using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Repositories
{
    public interface IPizzaRepo
    {
        public List<Pizza> GetPizzas();
        public List<Pizza> GetPizzasByName(string name);
        public Pizza GetPizzas(int id);
        public void CreatePizza(Pizza pizza, List<Ingredient> ingredients);
        public void UpdatePizza(Pizza pizza, List<Ingredient> ingredients);
        public void DeletePizza(int id);


    }
}
