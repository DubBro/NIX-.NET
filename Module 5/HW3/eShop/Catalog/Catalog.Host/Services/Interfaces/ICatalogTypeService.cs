using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<IList<CatalogTypeDto>> GetCatalogTypesAsync();
        Task<CatalogTypeDto> GetCatalogTypeByIdAsync(int id);
        Task<CatalogTypeDto> GetCatalogTypeByNameAsync(string name);
        Task<int> AddAsync(string name);
        Task<int> UpdateAsync(int id, string name);
        Task<int> DeleteAsync(int id);
    }
}
