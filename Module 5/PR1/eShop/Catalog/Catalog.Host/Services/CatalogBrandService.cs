using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
            _mapper = mapper;
        }

        public async Task<IList<CatalogBrandDto>> GetCatalogBrandsAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogBrandRepository.GetAllAsync();
                return _mapper.Map<IList<CatalogBrandDto>>(result);
            });
        }

        public async Task<CatalogBrandDto> GetCatalogBrandByIdAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogBrandRepository.GetByIdAsync(id);
                return _mapper.Map<CatalogBrandDto>(result);
            });
        }

        public async Task<CatalogBrandDto> GetCatalogBrandByNameAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _catalogBrandRepository.GetByNameAsync(name);
                return _mapper.Map<CatalogBrandDto>(result);
            });
        }

        public async Task<int> AddAsync(string name)
        {
            return await ExecuteSafeAsync(async () =>
            {
                return await _catalogBrandRepository.AddAsync(name);
            });
        }

        public async Task UpdateAsync(int id, string name)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _catalogBrandRepository.UpdateAsync(id, name);
            });
        }

        public async Task DeleteAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                await _catalogBrandRepository.DeleteAsync(id);
            });
        }
    }
}
