using System.Collections.Generic;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.Services
{
    public interface IService
    {
        List<Category> GetAllCategories();

        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);

        List<Book> GetAllBooks();
        List<Book> GetBooksByCategoryId(int categoryId);
        List<Book> GetFeaturedBooks();
        Book GetBookById(int id);

        Category AddCategory(Category category);
        List<Category> AddCategories(IEnumerable<Category> categories);

        Category UpdateCategory(Category category);

        void DeleteCategory(Category category);
        void DeleteCategories(params Category[] categories);
        void DeleteCategories(IEnumerable<Category> categories);
    }
}

