using Basket.Host.Models.Requests;
using Basket.Host.Models.Responses;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("basket.basket")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService, ILogger<BasketController> logger)
        {
            _basketService = basketService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddItemToCatalog(CreateProductRequest request)
        {
            var result = await _basketService.AddItemToCatalogAsync(request);
            return Ok(result);
        }
    }
}
