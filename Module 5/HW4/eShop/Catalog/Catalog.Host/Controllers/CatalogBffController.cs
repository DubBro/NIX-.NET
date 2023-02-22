using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly ICatalogTypeService _catalogTypeService;
    private readonly IOptions<CatalogConfig> _config;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        ICatalogBrandService catalogBrandService,
        ICatalogTypeService catalogTypeService,
        IOptions<CatalogConfig> config)
    {
        _logger = logger;
        _catalogService = catalogService;
        _catalogBrandService = catalogBrandService;
        _catalogTypeService = catalogTypeService;
        _config = config;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrands()
    {
        var result = await _catalogBrandService.GetCatalogBrandsAsync();
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes()
    {
        var result = await _catalogTypeService.GetCatalogTypesAsync();
        return Ok(result);
    }
}