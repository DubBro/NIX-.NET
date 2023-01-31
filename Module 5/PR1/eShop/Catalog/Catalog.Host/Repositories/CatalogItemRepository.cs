using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<IList<CatalogItemEntity>> GetAllAsync()
    {
        return await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .ToListAsync();
    }

    public async Task<PaginatedItems<CatalogItemEntity>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItemEntity>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int> AddAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItemEntity
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<CatalogItemEntity> GetByIdAsync(int id)
    {
        return await _dbContext.CatalogItems
            .Where(i => i.Id == id)
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .SingleAsync();
    }

    public async Task<IList<CatalogItemEntity>> GetByBrandAsync(int brandId)
    {
        return await _dbContext.CatalogItems
            .Where(i => i.CatalogBrandId == brandId)
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .ToListAsync();
    }

    public async Task<IList<CatalogItemEntity>> GetByTypeAsync(int typeId)
    {
        return await _dbContext.CatalogItems
           .Where(i => i.CatalogTypeId == typeId)
           .Include(i => i.CatalogBrand)
           .Include(i => i.CatalogType)
           .ToListAsync();
    }

    public async Task UpdateAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = new CatalogItemEntity
        {
            Id = id,
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        };

        _dbContext.Entry(item).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        _dbContext.Entry(await GetByIdAsync(id)).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync();
    }
}