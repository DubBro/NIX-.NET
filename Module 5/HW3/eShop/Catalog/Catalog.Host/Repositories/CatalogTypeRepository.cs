using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogTypeRepository> _logger;

        public CatalogTypeRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogTypeRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<IList<CatalogTypeEntity>> GetAllAsync()
        {
            return await _dbContext.CatalogTypes.ToListAsync();
        }

        public async Task<CatalogTypeEntity> GetByIdAsync(int id)
        {
            return await _dbContext.CatalogTypes.Where(t => t.Id == id).SingleAsync();
        }

        public async Task<CatalogTypeEntity> GetByNameAsync(string name)
        {
            return await _dbContext.CatalogTypes.Where(t => t.Type == name).SingleAsync();
        }

        public async Task<int> AddAsync(string typeName)
        {
            var type = await _dbContext.AddAsync(new CatalogTypeEntity() { Type = typeName });

            await _dbContext.SaveChangesAsync();

            return type.Entity.Id;
        }

        public async Task<int> UpdateAsync(int id, string name)
        {
            var type = new CatalogTypeEntity()
            {
                Id = id,
                Type = name
            };

            _dbContext.Entry(type).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return type.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            _dbContext.Entry(await GetByIdAsync(id)).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
