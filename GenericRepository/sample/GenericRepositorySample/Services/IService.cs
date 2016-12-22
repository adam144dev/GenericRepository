using System.Collections.Generic;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.Services
{
    public interface IService
    {
        IList<Category> GetAllCategories();

        IList<Author> GetAllAuthors();
        Author GetAuthorById(int id);

        IList<Book> GetAllBooks();
        IList<Book> GetBooksByCategoryId(int categoryId);
        IList<Book> GetFeaturedBooks();
        Book GetBookById(int id);
    }
}

