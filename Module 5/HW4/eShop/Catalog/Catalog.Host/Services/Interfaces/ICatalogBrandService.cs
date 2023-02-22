using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<IList<CatalogBrandDto>> GetCatalogBrandsAsync();
    }
}
