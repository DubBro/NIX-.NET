namespace Catalog.UnitTests.Services
{
    public class CatalogTypeServiceTest
    {
        private readonly ICatalogTypeService _catalogTypeService;

        private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogTypeService>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly CatalogTypeEntity _testTypeEntity = new CatalogTypeEntity() { Id = 1, Type = "Type" };
        private readonly CatalogTypeDto _testTypeDto = new CatalogTypeDto() { Id = 1, Type = "Type" };

        public CatalogTypeServiceTest()
        {
            _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<CatalogTypeService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogTypeService = new CatalogTypeService(_dbContextWrapper.Object, _logger.Object, _catalogTypeRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetCatalogTypesAsync_Success()
        {
            // Arrange
            var listCatalogTypeEntity = new List<CatalogTypeEntity>() { _testTypeEntity };
            var listCatalogTypeDto = new List<CatalogTypeDto>() { _testTypeDto };

            _catalogTypeRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(listCatalogTypeEntity);
            _mapper.Setup(m => m.Map<IList<CatalogTypeDto>>(
                It.Is<IList<CatalogTypeEntity>>(i => i.Equals(listCatalogTypeEntity)))).Returns(listCatalogTypeDto);

            // Act
            var result = await _catalogTypeService.GetCatalogTypesAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().AllBeOfType<CatalogTypeDto>();
            result.Should().BeEquivalentTo(listCatalogTypeDto);
            result.First().Should().Be(_testTypeDto);
        }

        [Fact]
        public async Task GetCatalogTypesAsync_Failed()
        {
            // Arrange
            _catalogTypeRepository.Setup(r => r.GetAllAsync()).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogTypeService.GetCatalogTypesAsync();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogTypeByIdAsync_Success()
        {
            // Arrange
            int testId = 2;

            _catalogTypeRepository.Setup(r => r.GetByIdAsync(testId)).ReturnsAsync(_testTypeEntity);
            _mapper.Setup(m => m.Map<CatalogTypeDto>(
                It.Is<CatalogTypeEntity>(i => i.Equals(_testTypeEntity)))).Returns(_testTypeDto);

            // Act
            var result = await _catalogTypeService.GetCatalogTypeByIdAsync(testId);

            // Assert
            result.Should().Be(_testTypeDto);
        }

        [Fact]
        public async Task GetCatalogTypeByIdAsync_Failed()
        {
            // Arrange
            int testId = 1000;

            _catalogTypeRepository.Setup(r => r.GetByIdAsync(testId)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogTypeService.GetCatalogTypeByIdAsync(testId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogTypeByNameAsync_Success()
        {
            // Arrange
            string testName = "name";

            _catalogTypeRepository.Setup(r => r.GetByNameAsync(testName)).ReturnsAsync(_testTypeEntity);
            _mapper.Setup(m => m.Map<CatalogTypeDto>(
                It.Is<CatalogTypeEntity>(i => i.Equals(_testTypeEntity)))).Returns(_testTypeDto);

            // Act
            var result = await _catalogTypeService.GetCatalogTypeByNameAsync(testName);

            // Assert
            result.Should().Be(_testTypeDto);
        }

        [Fact]
        public async Task GetCatalogTypeByNameAsync_Failed()
        {
            // Arrange
            string testName = "name";

            _catalogTypeRepository.Setup(r => r.GetByNameAsync(testName)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogTypeService.GetCatalogTypeByNameAsync(testName);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // Arrange
            int testResult = 1;

            _catalogTypeRepository.Setup(r => r.AddAsync(_testTypeDto.Type)).ReturnsAsync(testResult);

            // Act
            var result = await _catalogTypeService.AddAsync(_testTypeDto.Type);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            // Arrange
            int testResult = default;

            _catalogTypeRepository.Setup(r => r.AddAsync(_testTypeDto.Type)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogTypeService.AddAsync(_testTypeDto.Type);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            // Arrange
            int testResult = 2;

            _catalogTypeRepository.Setup(r => r.UpdateAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(testResult);

            // Act
            var result = await _catalogTypeService.UpdateAsync(_testTypeDto.Id, _testTypeDto.Type);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateAsync_Failed()
        {
            // Arrange
            int testResult = default;

            _catalogTypeRepository.Setup(r => r.UpdateAsync(It.IsAny<int>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogTypeService.UpdateAsync(_testTypeDto.Id, _testTypeDto.Type);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            // Arrange
            int testId = 2;

            _catalogTypeRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync(testId);

            // Act
            var result = await _catalogTypeService.DeleteAsync(testId);

            // Assert
            result.Should().Be(testId);
        }

        [Fact]
        public async Task DeleteAsync_Failed()
        {
            // Arrange
            int testId = default;

            _catalogTypeRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogTypeService.DeleteAsync(_testTypeDto.Id);

            // Assert
            result.Should().Be(testId);
        }
    }
}
