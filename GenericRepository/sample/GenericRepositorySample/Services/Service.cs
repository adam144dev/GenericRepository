using System.Collections.Generic;
using System.Diagnostics;
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


        public void AddCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void AddCategories(IEnumerable<Category> categories)
        {
            //Debug.Assert((categories != null) && (categories.Any()), nameof(AddCategories), "(categories != null) && (categories.Any())");
            _categoryRepository.Add(categories);
        }

        public void AddCategories(params Category[] categories)
            => AddCategories((IEnumerable<Category>)categories);


        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }

        public void UpdateCategory(IEnumerable<Category> categories)
        {
            //Debug.Assert((categories != null) && (categories.Any()), nameof(UpdateCategory), "(categories != null) && (categories.Any())");
            _categoryRepository.Update(categories);
        }

        public void UpdateCategory(params Category[] categories)
            => UpdateCategory((IEnumerable<Category>)categories);


        public void DeleteCategory(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public void DeleteCategories(IEnumerable<Category> categories)
        {
            //Debug.Assert((categories != null) && (categories.Any()), nameof(DeleteCategories), "(categories != null) && (categories.Any())");
            _categoryRepository.Delete(categories);
        }

        public void DeleteCategories(params Category[] categories)
            => DeleteCategories((IEnumerable<Category>)categories);
    }
}

