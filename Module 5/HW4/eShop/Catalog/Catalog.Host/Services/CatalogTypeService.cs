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
            ICatalogTypeRepository catalogTypeRepository,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
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
    }
}
