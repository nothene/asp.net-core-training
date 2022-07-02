using MvcMovie.Models;
using MvcMovie.Data;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizza.AsNoTracking().ToList();
        }

        public Pizza? GetById(int id)
        {
            return _context.Pizza
                .Include(p => p.Toppings)
                .Include(p => p.Sauce)
                .AsNoTracking()
                .SingleOrDefault(p => p.Id == id);
        }

        public Pizza Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return newPizza;
        }

        public void UpdateSauce(int pizzaId, int sauceId)
        {
            var pizza = _context.Pizza.Find(pizzaId);
            var sauce = _context.Sauces.Find(sauceId);

            if(pizza is null || sauce is null)
            {
                throw new InvalidOperationException("Pizza or sauce does not exist");
            }

            pizza.Sauce = sauce;

            _context.SaveChanges();
        }

        public void AddTopping(int pizzaId, int toppingId)
        {
            var pizza = _context.Pizza.Find(pizzaId);
            var topping = _context.Toppings.Find(toppingId);

            if(pizza is null || topping is null)
            {
                throw new InvalidOperationException("Pizza or topping does not exist");
            }

            if(pizza.Toppings is null)
            {
                pizza.Toppings = new List<Topping>();
            }

            pizza.Toppings.Add(topping);

            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var pizza = _context.Pizza.Find(id);
            if(pizza is not null)
            {
                _context.Pizza.Remove(pizza);
                _context.SaveChangesAsync();
            }
        }
    }
}
