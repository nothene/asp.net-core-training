using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    [Route("products/")]
    public class ProductsController : Controller
    {
        JsonProductService _productService;

        [BindProperty(Name = "deep", SupportsGet = true)]
        public int? dankness { get; set; }
        public ProductList Products { get; set; }
        public ProductsController(JsonProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Products = new ProductList();
            //Products.Products = _productService.GetProducts();

            Products = new ProductList
            {
                Products = _productService.GetProducts()
            };

            foreach(var product in Products.Products)
            {
                Console.WriteLine(product.Id, product.Description);
            }
            Console.WriteLine("dankness: " + this.dankness);
            return View("Index", Products);
        }

        [HttpPost]
        public string Index2()
        {
            return "dankness is here";
        }
    }
}
