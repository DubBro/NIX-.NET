using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogItemService
    {
        Task<IList<CatalogItemDto>> GetCatalogItemsAsync();
        Task<CatalogItemDto> GetCatalogItemByIdAsync(int id);
        Task<int> AddAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
        Task UpdateAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
        Task DeleteAsync(int id);
    }
}