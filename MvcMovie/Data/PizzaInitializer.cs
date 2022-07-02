using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class PizzaInitializer
    {
        public static void Initialize(PizzaContext context)
        {
            if(context.Pizza.Any() && context.Pizza.Any() && context.Pizza.Any())
            {
                return;
            }

            var pepperoni = new Topping { Name = "Pepperoni", Calories = 130};
            var sausage = new Topping { Name = "Sausage", Calories = 100 };
            var ham = new Topping { Name = "Ham", Calories = 70 };
            var chicken = new Topping { Name = "Chicken", Calories = 50 };
            var pineapple = new Topping { Name = "Pineapple", Calories = 75 };

            var tomato = new Sauce { Name = "Tomato", IsVegan = true };
            var alfredo = new Sauce { Name = "Alfredo", IsVegan = false };

            var pizzas = new Pizza[]
            {
                new Pizza
                {
                    Name = "Meat Lovers",
                    Sauce = tomato,
                    Toppings = new List<Topping>
                    {
                        pepperoni,
                        sausage,
                        ham,
                        chicken
                    }
                },
                new Pizza
                {
                    Name = "Hawaiian",
                    Sauce = tomato,
                    Toppings = new List<Topping>
                    {
                        pineapple,
                        ham
                    }
                },
                new Pizza
                {
                    Name = "Alfredo Chicken",
                    Sauce = alfredo,
                    Toppings = new List<Topping>
                    {
                        chicken
                    }
                }
            };

            context.Pizza.AddRange(pizzas);
            context.SaveChanges();
        }
    }
}
