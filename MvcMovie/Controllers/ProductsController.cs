using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Services;

namespace MvcMovie.Controllers
{
    public class ProductsController : Controller
    {
        JsonProductService _productService;
        public ProductList Products { get; set; }
        public ProductsController(JsonProductService productService)
        {
            _productService = productService;
        }

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
            Console.WriteLine("dank");
            return View("Index", Products);
        }
    }
}
