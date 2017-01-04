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

        void AddCategory(Category category);
        void AddCategories(IEnumerable<Category> categories);
        void AddCategories(params Category[] categories);

        void UpdateCategory(Category category);
        void UpdateCategory(IEnumerable<Category> categories);
        void UpdateCategory(params Category[] categories);

        void DeleteCategory(Category category);
        void DeleteCategories(IEnumerable<Category> categories);
        void DeleteCategories(params Category[] categories);
    }
}

