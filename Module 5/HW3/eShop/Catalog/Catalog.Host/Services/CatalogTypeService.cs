using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly IMapper _mapper;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }

        public async Task<IList<CatalogTypeDto>> GetCatalogTypesAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogTypeRepository.GetAllAsync();
                return _mapper.Map<IList<CatalogTypeDto>>(result);
            });
        }

        public async Task<CatalogTypeDto> GetCatalogTypeByIdAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogTypeRepository.GetByIdAsync(id);
                return _mapper.Map<CatalogTypeDto>(result);
            });
        }

        public async Task<CatalogTypeDto> GetCatalogTypeByNameAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogTypeRepository.GetByNameAsync(name);
                return _mapper.Map<CatalogTypeDto>(result);
            });
        }

        public async Task<int> AddAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _catalogTypeRepository.AddAsync(name);
            });
        }

        public async Task<int> UpdateAsync(int id, string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _catalogTypeRepository.UpdateAsync(id, name);
            });
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _catalogTypeRepository.DeleteAsync(id);
            });
        }
    }
}
