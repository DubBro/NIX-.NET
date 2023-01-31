using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogItemRepository
    {
        Task<IList<CatalogItemEntity>> GetAllAsync();
        Task<PaginatedItems<CatalogItemEntity>> GetByPageAsync(int pageIndex, int pageSize);
        Task<int> AddAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
        Task<CatalogItemEntity> GetByIdAsync(int id);
        Task<IList<CatalogItemEntity>> GetByBrandAsync(int brandId);
        Task<IList<CatalogItemEntity>> GetByTypeAsync(int typeId);
        Task UpdateAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
        Task DeleteAsync(int id);
    }
}