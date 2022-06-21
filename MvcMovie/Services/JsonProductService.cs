using MvcMovie.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MvcMovie.Services
{
    public class JsonProductService
    {
        public JsonProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                        new JsonSerializerOptions{ PropertyNameCaseInsensitive = true });
            }            
        }
    }
}
