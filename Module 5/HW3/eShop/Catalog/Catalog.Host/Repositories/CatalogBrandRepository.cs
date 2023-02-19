using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int> AddAsync(string brandName)
        {
            var brand = await _dbContext.CatalogBrands.AddAsync(new CatalogBrandEntity() { Brand = brandName });

            await _dbContext.SaveChangesAsync();

            return brand.Entity.Id;
        }

        public async Task<IList<CatalogBrandEntity>> GetAllAsync()
        {
            return await _dbContext.CatalogBrands.ToListAsync();
        }

        public async Task<CatalogBrandEntity> GetByIdAsync(int id)
        {
            return await _dbContext.CatalogBrands.Where(b => b.Id == id).SingleAsync();
        }

        public async Task<CatalogBrandEntity> GetByNameAsync(string name)
        {
            return await _dbContext.CatalogBrands.Where(b => b.Brand == name).SingleAsync();
        }

        public async Task<int> UpdateAsync(int id, string name)
        {
            var brand = new CatalogBrandEntity()
            {
                Id = id,
                Brand = name
            };

            _dbContext.Entry(brand).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return brand.Id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            _dbContext.Entry(await GetByIdAsync(id)).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return id;
        }
    }
}
