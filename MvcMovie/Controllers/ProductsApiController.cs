using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Services;
using MvcMovie.Models;
using System.Text.Json;

namespace MvcMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        JsonProductService _productService;
        public ProductList Products { get; set; }
        public ProductsApiController(JsonProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }

        [HttpGet]
        [Route("rate")]
        public ActionResult AddRating([FromQuery] string productId, [FromQuery] int rating)
        {
            var products = Get();

            var query = products.First(x => x.Id == productId);

            if (query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            using (var fs = System.IO.File.OpenWrite(_productService.JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(new Utf8JsonWriter(fs, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                }), products);
                //JsonSerializer.Serialize<IEnumerable<Product>>(fs, products);
            }

            return Ok();    
        }
    }
}
