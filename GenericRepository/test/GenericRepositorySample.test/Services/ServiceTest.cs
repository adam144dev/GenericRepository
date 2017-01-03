using GenericRepositorySample.Models;
using GenericRepositorySample.Repositories;
using GenericRepositorySample.Services;
using System.Linq;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using GenericRepositorySample.test.Extensions;

namespace GenericRepositorySample.test.Services
{
    public class ServiceTest
    {
        [Fact]
        public void GetAllCategories()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            // Act
            var r = Service.GetAllCategories();
            //Assert
            Assert.Equal(4, r.Count);
        }

        [Fact]
        public void GetAllAuthors()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
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
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            // Act
            var r = Service.GetAuthorById(id);
            //Assert
            Assert.Equal(id, r.Id);
        }

        [Fact]
        public void GetAllBooks()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
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
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            // Act
            var r = Service.GetBooksByCategoryId(id);
            //Assert
            Assert.Equal(count, r.Count);
        }

        [Fact]
        public void GetFeaturedBooks()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
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
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            // Act
            var r = Service.GetBookById(id);
            //Assert
            Assert.Equal(id, r.Id);
        }

        [Fact]
        public void AddCategory()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            var e = new Category { Name = "newEntity" };
            // Act
            var r = Service.AddCategory(e);
            //Assert
            Assert.Single(fakeRepoData.Categories.Where(f => f.Name == "newEntity"));
        }

        [Fact]
        public void AddCategories()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);

            var e = new Category[]
            {
                new Category { Name = "newEntity1" },
                new Category { Name = "newEntity2" }
            };

            // Act
            var r = Service.AddCategories(e);
            //Assert
            Assert.Equal(2, fakeRepoData.Categories.Where(f => f.Name.Contains("newEntity")).Count());
        }

       [Fact]
        public void DeleteCategory()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            var e = fakeRepoData.Categories[0];
            // Act
            Service.DeleteCategory(e);
            //Assert
            Assert.Equal(0, fakeRepoData.Categories.Where(f => f.Name == e.Name).Count());
        }

        [Fact]
        public void DeleteCategoriesArray()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            var e = fakeRepoData.Categories.Where(c => c.Id < 4).ToArray();
            // Act
            Service.DeleteCategories(e);
            //Assert
            Assert.Equal(1, fakeRepoData.Categories.Count());
            Assert.True(fakeRepoData.Categories.Single().Id == 4);
        }

        [Fact]
        public void DeleteCategoriesIEnumerable()
        {
            // Arrange
            var fakeRepoData = new FakeRepositoryData();
            var Service = GetServiceOnMock(fakeRepoData);
            var e = fakeRepoData.Categories.Where(c => c.Id < 4);
            // Act
            Service.DeleteCategories(e);
            //Assert
            Assert.Equal(1, fakeRepoData.Categories.Count());
            Assert.True(fakeRepoData.Categories.Single().Id == 4);
        }


        private IService GetServiceOnMock(FakeRepositoryData fakeRepoData)
        {
            var mockC = new Mock<ICategoryRepository>(MockBehavior.Strict);
            var mockA = new Mock<IAuthorRepository>(MockBehavior.Strict);
            var mockB = new Mock<IBookRepository>(MockBehavior.Strict);

            mockC.Setup(m => m.Entities).Returns(fakeRepoData.Categories.AsQueryable());
            mockA.Setup(m => m.Entities).Returns(fakeRepoData.Authors.AsQueryable());
            mockB.Setup(m => m.Entities).Returns(fakeRepoData.Books.AsQueryable());

            mockC.Setup(m => m.Include(It.IsAny<string>())).Returns(fakeRepoData.Categories.AsQueryable());
            mockA.Setup(m => m.Include(It.IsAny<string>())).Returns(fakeRepoData.Authors.AsQueryable());
            mockB.Setup(m => m.Include(It.IsAny<string>())).Returns(fakeRepoData.Books.AsQueryable());

            mockC.Setup(m => m.Add(It.IsAny<Category[]>())).Callback((Category[] e) => fakeRepoData.Categories.AddRange(e));

            mockC.Setup(m => m.Delete(It.IsAny<Category>())).Callback((Category e) => fakeRepoData.Categories.Remove(e)).Returns((Category e) => e);
            mockC.Setup(m => m.Delete(It.IsAny<Category[]>())).Callback((Category[] e) => fakeRepoData.Categories.RemoveRange(e));
            mockC.Setup(m => m.Delete(It.IsAny<IEnumerable<Category>>())).Callback((IEnumerable<Category> e) => fakeRepoData.Categories.RemoveRange(e.ToArray()));

            return new Service(mockC.Object, mockA.Object, mockB.Object);
        }
    }
}
