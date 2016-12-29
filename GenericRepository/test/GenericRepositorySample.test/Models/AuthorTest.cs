using GenericRepositorySample.Models;
using Xunit;

namespace GenericRepositorySample.test.Models
{
    public class AuthorTest
    {
        [Fact]
        public void VerifyFullName()
        {
            // Arrange
            var a = new Author { FirstName = "firstname", LastName = "lastname" };

            // Act
            // nothing

            //Assert
            Assert.Equal("firstname lastname", a.FullName);
        }

        [Fact]
        public void VerifyFullNameChange()
        {
            // Arrange
            var a = new Author { FirstName = "firstname", LastName = "lastname" };

            // Act
            a.FirstName = "newfirstname";
            a.LastName = "newlastname";

            //Assert
            Assert.Equal("newfirstname newlastname", a.FullName);
        }

        // TBC...
    }
}
