using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;

        public CatalogItemService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogItemRepository catalogItemRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogItemRepository = catalogItemRepository;
            _mapper = mapper;
        }

        public async Task<IList<CatalogItemDto>> GetCatalogItemsAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogItemRepository.GetAllAsync();
                return _mapper.Map<IList<CatalogItemDto>>(result);
            });
        }

        public async Task<CatalogItemDto> GetCatalogItemByIdAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogItemRepository.GetByIdAsync(id);
                return _mapper.Map<CatalogItemDto>(result);
            });
        }

        public async Task<int> AddAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _catalogItemRepository.AddAsync(name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName);
            });
        }

        public async Task<int> UpdateAsync(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _catalogItemRepository.UpdateAsync(id, name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName);
            });
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _catalogItemRepository.DeleteAsync(id);
            });
        }
    }
}