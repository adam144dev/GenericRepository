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


        public IList<Category> GetAllCategories() 
            => _categoryRepository.Entities.ToList();
        

        public IList<Author> GetAllAuthors() 
            => _authorRepository.Entities.ToList();

        public Author GetAuthorById(int id) 
            => _authorRepository.Entities.SingleOrDefault(e => e.Id == id);


        public IList<Book> GetAllBooks() 
            => _bookRepository.Entities.ToList();

        public IList<Book> GetBooksByCategoryId(int categoryId) 
            =>  _bookRepository
                    .Include("Author")
                    .Where(e => e.CategoryId == categoryId)
                    .OrderByDescending(e => e.Featured)
                    .ToList();

        public IList<Book> GetFeaturedBooks()
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
        public IList<Category> AddCategories(IList<Category> categories)
        {
            _categoryRepository.Add(categories.ToArray());
            return categories;
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

    }
}

