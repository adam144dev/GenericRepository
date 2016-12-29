using GenericRepositorySample.Repositories;
using GenericRepositorySample.Services;
using Moq;
using Xunit;

namespace GenericRepositorySample.test.Services
{
    public class ServiceTest
    {
        [Fact]
        public void GetAllCategories()
        {
            // Arrange
            var Service = GetServiceOnMock();
            // Act
            var r = Service.GetAllCategories();
            //Assert
            Assert.Equal(4, r.Count);
        }

        [Fact]
        public void GetAllAuthors()
        {
            // Arrange
            var Service = GetServiceOnMock();
            // Act
            var r = Service.GetAllAuthors();
            //Assert
            Assert.Equal(2, r.Count);
        }

        [Theory]
        [InlineData(2)]
        public void GetAuthorById(int id)
        {
            // Arrange
            var Service = GetServiceOnMock();
            // Act
            var r = Service.GetAuthorById(id);
            //Assert
            Assert.Equal(id, r.Id);
        }

        [Fact]
        public void GetAllBooks()
        {
            // Arrange
            var Service = GetServiceOnMock();
            // Act
            var r = Service.GetAllBooks();
            //Assert
            Assert.Equal(4, r.Count);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(4, 0)]
        public void GetBooksByCategoryId(int id, int count)
        {
            // Arrange
            var Service = GetServiceOnMock();
            // Act
            var r = Service.GetBooksByCategoryId(id);
            //Assert
            Assert.Equal(count, r.Count);
        }

        [Fact]
        public void GetFeaturedBooks()
        {
            // Arrange
            var Service = GetServiceOnMock();
            // Act
            var r = Service.GetFeaturedBooks();
            //Assert
            Assert.Equal(2, r.Count);
        }

        [Theory]
        [InlineData(4)]
        public void GetBookById(int id)
        {
            // Arrange
            var Service = GetServiceOnMock();
            // Act
            var r = Service.GetBookById(id);
            //Assert
            Assert.Equal(id, r.Id);
        }


        private IService GetServiceOnMock()
        {
            var fakeRepoData = new FakeRepositoryData();

            var mockC = new Mock<ICategoryRepository>();
            var mockA = new Mock<IAuthorRepository>();
            var mockB = new Mock<IBookRepository>();

            mockC.SetupGet(m => m.Entities).Returns(fakeRepoData.Categories);
            mockA.SetupGet(m => m.Entities).Returns(fakeRepoData.Authors);
            mockB.SetupGet(m => m.Entities).Returns(fakeRepoData.Books);

            mockC.Setup(m => m.Include(It.IsAny<string>())).Returns(fakeRepoData.Categories);
            mockA.Setup(m => m.Include(It.IsAny<string>())).Returns(fakeRepoData.Authors);
            mockB.Setup(m => m.Include(It.IsAny<string>())).Returns(fakeRepoData.Books);

            return new Service(mockC.Object, mockA.Object, mockB.Object);
        }
    }
}
