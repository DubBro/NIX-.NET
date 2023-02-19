using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<IList<CatalogTypeEntity>> GetAllAsync();
        Task<CatalogTypeEntity> GetByIdAsync(int id);
        Task<CatalogTypeEntity> GetByNameAsync(string name);
        Task<int> AddAsync(string typeName);
        Task<int> UpdateAsync(int id, string name);
        Task<int> DeleteAsync(int id);
    }
}
