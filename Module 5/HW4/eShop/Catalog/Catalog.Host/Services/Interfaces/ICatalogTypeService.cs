using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<IList<CatalogTypeDto>> GetCatalogTypesAsync();
    }
}
