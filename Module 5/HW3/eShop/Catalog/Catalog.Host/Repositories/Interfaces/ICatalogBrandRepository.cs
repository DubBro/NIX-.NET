using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<IList<CatalogBrandEntity>> GetAllAsync();
        Task<CatalogBrandEntity> GetByIdAsync(int id);
        Task<CatalogBrandEntity> GetByNameAsync(string name);
        Task<int> AddAsync(string brandName);
        Task<int> UpdateAsync(int id, string name);
        Task<int> DeleteAsync(int id);
    }
}
