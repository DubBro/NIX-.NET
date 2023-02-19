namespace Catalog.UnitTests.Services
{
    public class CatalogItemServiceTest
    {
        private readonly ICatalogItemService _catalogItemService;

        private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogItemService>> _logger;
        private readonly Mock<IMapper> _mapper;

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

        public CatalogItemServiceTest()
        {
            _catalogItemRepository = new Mock<ICatalogItemRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogItemService>>();
            _mapper = new Mock<IMapper>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogItemService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // Arrange
            var testResult = 1;

            _catalogItemRepository.Setup(s => s.AddAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // Act
            var result = await _catalogItemService.AddAsync(
                _testItemEntity.Name,
                _testItemEntity.Description,
                _testItemEntity.Price,
                _testItemEntity.AvailableStock,
                _testItemEntity.CatalogBrandId,
                _testItemEntity.CatalogTypeId,
                _testItemEntity.PictureFileName);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            // Arrange
            int testResult = default;

            _catalogItemRepository.Setup(s => s.AddAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogItemService.AddAsync(
                _testItemEntity.Name,
                _testItemEntity.Description,
                _testItemEntity.Price,
                _testItemEntity.AvailableStock,
                _testItemEntity.CatalogBrandId,
                _testItemEntity.CatalogTypeId,
                _testItemEntity.PictureFileName);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task GetCatalogItemsAsync_Success()
        {
            // Arrange
            var listCatalogItemEntity = new List<CatalogItemEntity>() { _testItemEntity };
            var listCatalogItemDto = new List<CatalogItemDto>() { _testItemDto };

            _catalogItemRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(listCatalogItemEntity);
            _mapper.Setup(m => m.Map<IList<CatalogItemDto>>(
                It.Is<IList<CatalogItemEntity>>(i => i.Equals(listCatalogItemEntity)))).Returns(listCatalogItemDto);

            // Act
            var result = await _catalogItemService.GetCatalogItemsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().AllBeOfType<CatalogItemDto>();
            result.Should().BeEquivalentTo(listCatalogItemDto);
            result.First().Should().Be(_testItemDto);
        }

        [Fact]
        public async Task GetCatalogItemsAsync_Failed()
        {
            // Arrange
            _catalogItemRepository.Setup(r => r.GetAllAsync()).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogItemService.GetCatalogItemsAsync();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogItemByIdAsync_Success()
        {
            // Arrange
            int testId = 1;

            _catalogItemRepository.Setup(r => r.GetByIdAsync(testId)).ReturnsAsync(_testItemEntity);
            _mapper.Setup(m => m.Map<CatalogItemDto>(
                It.Is<CatalogItemEntity>(i => i.Equals(_testItemEntity)))).Returns(_testItemDto);

            // Act
            var result = await _catalogItemService.GetCatalogItemByIdAsync(testId);

            // Assert
            result.Should().Be(_testItemDto);
        }

        [Fact]
        public async Task GetCatalogItemByIdAsync_Failed()
        {
            // Arrange
            int testId = 1000;

            _catalogItemRepository.Setup(r => r.GetByIdAsync(testId)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogItemService.GetCatalogItemByIdAsync(testId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            // Arrange
            int testResult = 7;

            _catalogItemRepository.Setup(r => r.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testResult);

            // Act
            var result = await _catalogItemService.UpdateAsync(
                _testItemDto.Id,
                _testItemEntity.Name,
                _testItemEntity.Description,
                _testItemEntity.Price,
                _testItemEntity.AvailableStock,
                _testItemEntity.CatalogBrandId,
                _testItemEntity.CatalogTypeId,
                _testItemEntity.PictureFileName);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateAsync_Failed()
        {
            // Arrange
            int testResult = default;

            _catalogItemRepository.Setup(r => r.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogItemService.UpdateAsync(
                _testItemDto.Id,
                _testItemEntity.Name,
                _testItemEntity.Description,
                _testItemEntity.Price,
                _testItemEntity.AvailableStock,
                _testItemEntity.CatalogBrandId,
                _testItemEntity.CatalogTypeId,
                _testItemEntity.PictureFileName);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            // Arrange
            int testId = 7;

            _catalogItemRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync(testId);

            // Act
            var result = await _catalogItemService.DeleteAsync(testId);

            // Assert
            result.Should().Be(testId);
        }

        [Fact]
        public async Task DeleteAsync_Failed()
        {
            // Arrange
            int testId = default;

            _catalogItemRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogItemService.DeleteAsync(_testItemDto.Id);

            // Assert
            result.Should().Be(testId);
        }
    }
}
