using Catalog.Host.Models.Dtos;
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
    private readonly ICatalogItemService _catalogItemService;
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        ICatalogItemService catalogItemService,
        ICatalogBrandService catalogBrandService,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogService = catalogService;
        _catalogItemService = catalogItemService;
        _catalogBrandService = catalogBrandService;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _catalogItemService.GetCatalogItemByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByBrand(string brandName)
    {
        var brand = await _catalogBrandService.GetCatalogBrandByNameAsync(brandName);
        var result = await _catalogService.GetCatalogItemsByBrandAsync(brand.Id);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByType(string typeName)
    {
        var type = await _catalogTypeService.GetCatalogTypeByNameAsync(typeName);
        var result = await _catalogService.GetCatalogItemsByTypeAsync(type.Id);
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