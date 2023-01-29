using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;

        private CatalogItem[] _items = new[]
        {
            new CatalogItem() { Id = 1, Name = "MacBook", Description = "The best MacBook", Price = 1000 },
            new CatalogItem() { Id = 2, Name = "Quake 3", Description = "Legendary videogame", Price = 499.99 },
            new CatalogItem() { Id = 3, Name = "OnePlus", Description = "Perfect smartphone", Price = 700.50 },
            new CatalogItem() { Id = 4, Name = "Mazda RX-7", Description = "Masterpiece of the automotive industry", Price = 2800 },
            new CatalogItem() { Id = 5, Name = "Toyota Supra", Description = "IT'S A SUPRAAAA!!!!", Price = 3000 },
        };

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCatalogItems")]
        public IEnumerable<CatalogItem> Get()
        {
            return _items;
        }
    }
}