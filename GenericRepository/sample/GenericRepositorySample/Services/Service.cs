using System.Collections.Generic;
using GenericRepositorySample.Models;
using GenericRepositorySample.Repositories;
using System.Linq;

namespace GenericRepositorySample.Services
{
    public class Service : IService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public Service(
            ICategoryRepository categoryRepository,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository
        )
        {
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }


        public List<Category> GetAllCategories() 
            => _categoryRepository.Entities.ToList();
        

        public List<Author> GetAllAuthors() 
            => _authorRepository.Entities.ToList();

        public Author GetAuthorById(int id) 
            => _authorRepository.Entities.SingleOrDefault(e => e.Id == id);


        public List<Book> GetAllBooks() 
            => _bookRepository.Entities.ToList();

        public List<Book> GetBooksByCategoryId(int categoryId) 
            =>  _bookRepository
                    .Include("Author")
                    .Where(e => e.CategoryId == categoryId)
                    .OrderByDescending(e => e.Featured)
                    .ToList();

        public List<Book> GetFeaturedBooks()
            => _bookRepository
                    .Include("Author")
                    .Where(e => e.Featured)
                    .ToList();

        public Book GetBookById(int id)
            => _bookRepository
                    .Include("Author")
                    .SingleOrDefault(e => e.Id == id);


        public Category AddCategory(Category category)
        {
            _categoryRepository.Add(category);
            return category;
        }
        public List<Category> AddCategories(IEnumerable<Category> categories)
        {
            _categoryRepository.Add(categories.ToArray());
            return categories.ToList();
        }

        public Category UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            return category;
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepository.Delete(category);
        }
        public void DeleteCategories(params Category[] categories)
        {
            _categoryRepository.Delete(categories);
        }
        public void DeleteCategories(IEnumerable<Category> categories)
        {
            _categoryRepository.Delete(categories);
        }
    }
}

