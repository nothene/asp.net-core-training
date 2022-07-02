namespace MvcMovie.Data
{
    public static class Extensionss
    {
        public static void InitDb(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PizzaContext>();
                context.Database.EnsureCreated();
                PizzaInitializer.Initialize(context);
            }
        }
    }
}
