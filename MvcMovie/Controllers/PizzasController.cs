using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class PizzasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
