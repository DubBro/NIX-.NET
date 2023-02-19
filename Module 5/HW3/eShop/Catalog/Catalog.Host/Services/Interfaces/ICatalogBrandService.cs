using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<IList<CatalogBrandDto>> GetCatalogBrandsAsync();
        Task<CatalogBrandDto> GetCatalogBrandByIdAsync(int id);
        Task<CatalogBrandDto> GetCatalogBrandByNameAsync(string name);
        Task<int> AddAsync(string name);
        Task<int> UpdateAsync(int id, string name);
        Task<int> DeleteAsync(int id);
    }
}
