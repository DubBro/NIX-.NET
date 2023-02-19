namespace Catalog.UnitTests.Services
{
    public class CatalogBrandServiceTest
    {
        private readonly ICatalogBrandService _catalogBrandService;

        private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogBrandService>> _logger;
        private readonly Mock<IMapper> _mapper;

        private readonly CatalogBrandEntity _testBrandEntity = new CatalogBrandEntity() { Id = 1, Brand = "Brand" };
        private readonly CatalogBrandDto _testBrandDto = new CatalogBrandDto() { Id = 1, Brand = "Brand" };

        public CatalogBrandServiceTest()
        {
            _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<CatalogBrandService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetCatalogBrandsAsync_Success()
        {
            // Arrange
            var listCatalogBrandEntity = new List<CatalogBrandEntity>() { _testBrandEntity };
            var listCatalogBrandDto = new List<CatalogBrandDto>() { _testBrandDto };

            _catalogBrandRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(listCatalogBrandEntity);
            _mapper.Setup(m => m.Map<IList<CatalogBrandDto>>(
                It.Is<IList<CatalogBrandEntity>>(i => i.Equals(listCatalogBrandEntity)))).Returns(listCatalogBrandDto);

            // Act
            var result = await _catalogBrandService.GetCatalogBrandsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().AllBeOfType<CatalogBrandDto>();
            result.Should().BeEquivalentTo(listCatalogBrandDto);
            result.First().Should().Be(_testBrandDto);
        }

        [Fact]
        public async Task GetCatalogBrandsAsync_Failed()
        {
            // Arrange
            _catalogBrandRepository.Setup(r => r.GetAllAsync()).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogBrandService.GetCatalogBrandsAsync();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogBrandByIdAsync_Success()
        {
            // Arrange
            int testId = 2;

            _catalogBrandRepository.Setup(r => r.GetByIdAsync(testId)).ReturnsAsync(_testBrandEntity);
            _mapper.Setup(m => m.Map<CatalogBrandDto>(
                It.Is<CatalogBrandEntity>(i => i.Equals(_testBrandEntity)))).Returns(_testBrandDto);

            // Act
            var result = await _catalogBrandService.GetCatalogBrandByIdAsync(testId);

            // Assert
            result.Should().Be(_testBrandDto);
        }

        [Fact]
        public async Task GetCatalogBrandByIdAsync_Failed()
        {
            // Arrange
            int testId = 1000;

            _catalogBrandRepository.Setup(r => r.GetByIdAsync(testId)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogBrandService.GetCatalogBrandByIdAsync(testId);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCatalogBrandByNameAsync_Success()
        {
            // Arrange
            string testName = "name";

            _catalogBrandRepository.Setup(r => r.GetByNameAsync(testName)).ReturnsAsync(_testBrandEntity);
            _mapper.Setup(m => m.Map<CatalogBrandDto>(
                It.Is<CatalogBrandEntity>(i => i.Equals(_testBrandEntity)))).Returns(_testBrandDto);

            // Act
            var result = await _catalogBrandService.GetCatalogBrandByNameAsync(testName);

            // Assert
            result.Should().Be(_testBrandDto);
        }

        [Fact]
        public async Task GetCatalogBrandByNameAsync_Failed()
        {
            // Arrange
            string testName = "name";

            _catalogBrandRepository.Setup(r => r.GetByNameAsync(testName)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogBrandService.GetCatalogBrandByNameAsync(testName);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task AddAsync_Success()
        {
            // Arrange
            int testResult = 1;

            _catalogBrandRepository.Setup(r => r.AddAsync(_testBrandDto.Brand)).ReturnsAsync(testResult);

            // Act
            var result = await _catalogBrandService.AddAsync(_testBrandDto.Brand);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task AddAsync_Failed()
        {
            // Arrange
            int testResult = default;

            _catalogBrandRepository.Setup(r => r.AddAsync(_testBrandDto.Brand)).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogBrandService.AddAsync(_testBrandDto.Brand);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateAsync_Success()
        {
            // Arrange
            int testResult = 2;

            _catalogBrandRepository.Setup(r => r.UpdateAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(testResult);

            // Act
            var result = await _catalogBrandService.UpdateAsync(_testBrandDto.Id, _testBrandDto.Brand);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task UpdateAsync_Failed()
        {
            // Arrange
            int testResult = default;

            _catalogBrandRepository.Setup(r => r.UpdateAsync(It.IsAny<int>(), It.IsAny<string>())).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogBrandService.UpdateAsync(_testBrandDto.Id, _testBrandDto.Brand);

            // Assert
            result.Should().Be(testResult);
        }

        [Fact]
        public async Task DeleteAsync_Success()
        {
            // Arrange
            int testId = 2;

            _catalogBrandRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync(testId);

            // Act
            var result = await _catalogBrandService.DeleteAsync(testId);

            // Assert
            result.Should().Be(testId);
        }

        [Fact]
        public async Task DeleteAsync_Failed()
        {
            // Arrange
            int testId = default;

            _catalogBrandRepository.Setup(r => r.DeleteAsync(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _catalogBrandService.DeleteAsync(_testBrandDto.Id);

            // Assert
            result.Should().Be(testId);
        }
    }
}
