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
            ICatalogBrandRepository catalogBrandRepository,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
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
    }
}
