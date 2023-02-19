using Catalog.Host.Models.Response;

namespace Catalog.UnitTests.Services
{
    public class CatalogServiceTest
    {
        private readonly ICatalogService _catalogService;

        private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        private readonly CatalogItemEntity _testItemEntity = new CatalogItemEntity()
        {
            Name = "Name",
            Description = "Description",
            Price = 1000,
            AvailableStock = 100,
            CatalogBrandId = 1,
            CatalogTypeId = 1,
            PictureFileName = "1.png"
        };

        private readonly CatalogItemDto _testItemDto = new CatalogItemDto()
        {
            Id = 1,
            Name = "Name",
            Description = "Description",
            Price = 1000,
            AvailableStock = 100,
            CatalogBrand = new CatalogBrandDto() { Id = 1, Brand = "TestBrand" },
            CatalogType = new CatalogTypeDto() { Id = 1, Type = "TestType" },
            PictureUrl = "test/1.png"
        };

        public CatalogServiceTest()
        {
            _catalogItemRepository = new Mock<ICatalogItemRepository>();
            _mapper = new Mock<IMapper>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogService = new CatalogService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetCatalogItemsAsync_Success()
        {
            // Arrange
            var testPageIndex = 0;
            var testPageSize = 4;
            var testTotalCount = 12;
            var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogItemEntity>()
            {
                Data = new List<CatalogItemEntity>()
                {
                    _testItemEntity
                },
                TotalCount = testTotalCount,
            };

            _catalogItemRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedItemsSuccess);
            _mapper.Setup(s => s.Map<CatalogItemDto>(
                It.Is<CatalogItemEntity>(i => i.Equals(_testItemEntity)))).Returns(_testItemDto);

            // Act
            var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Count.Should().Be(testTotalCount);
            result.PageIndex.Should().Be(testPageIndex);
            result.PageSize.Should().Be(testPageSize);
        }

        [Fact]
        public async Task GetCatalogItemsAsync_Failed()
        {
            // Arrange
            var testPageIndex = 1000;
            var testPageSize = 10000;

            _catalogItemRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

            // Act
            var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogItemsByBrandAsync_Success()
        {
            // Arrange
            int testBrandId = 4;
            var listCatalogItemEntity = new List<CatalogItemEntity>() { _testItemEntity };
            var listCatalogItemDto = new List<CatalogItemDto>() { _testItemDto };

            _catalogItemRepository.Setup(r => r.GetByBrandAsync(testBrandId)).ReturnsAsync(listCatalogItemEntity);
            _mapper.Setup(m => m.Map<IList<CatalogItemDto>>(
                It.Is<IList<CatalogItemEntity>>(i => i.Equals(listCatalogItemEntity)))).Returns(listCatalogItemDto);

            // Act
            var result = await _catalogService.GetCatalogItemsByBrandAsync(testBrandId);

            // Assert
            result.Should().NotBeNull();
            result.Should().AllBeOfType<CatalogItemDto>();
            result.Should().BeEquivalentTo(listCatalogItemDto);
            result.First().Should().Be(_testItemDto);
        }

        [Fact]
        public async Task GetCatalogItemsByBrandAsync_Failed()
        {
            // Arrange
            int testBrandId = 4;

            _catalogItemRepository.Setup(r => r.GetByBrandAsync(testBrandId)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogService.GetCatalogItemsByBrandAsync(testBrandId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogItemsByTypeAsync_Success()
        {
            // Arrange
            int testTypeId = 4;
            var listCatalogItemEntity = new List<CatalogItemEntity>() { _testItemEntity };
            var listCatalogItemDto = new List<CatalogItemDto>() { _testItemDto };

            _catalogItemRepository.Setup(r => r.GetByTypeAsync(testTypeId)).ReturnsAsync(listCatalogItemEntity);
            _mapper.Setup(m => m.Map<IList<CatalogItemDto>>(
                It.Is<IList<CatalogItemEntity>>(i => i.Equals(listCatalogItemEntity)))).Returns(listCatalogItemDto);

            // Act
            var result = await _catalogService.GetCatalogItemsByTypeAsync(testTypeId);

            // Assert
            result.Should().NotBeNull();
            result.Should().AllBeOfType<CatalogItemDto>();
            result.Should().BeEquivalentTo(listCatalogItemDto);
            result.First().Should().Be(_testItemDto);
        }

        [Fact]
        public async Task GetCatalogItemsByTypeAsync_Failed()
        {
            // Arrange
            int testTypeId = 4;

            _catalogItemRepository.Setup(r => r.GetByTypeAsync(testTypeId)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogService.GetCatalogItemsByTypeAsync(testTypeId);

            // Assert
            result.Should().BeNull();
        }
    }
}
