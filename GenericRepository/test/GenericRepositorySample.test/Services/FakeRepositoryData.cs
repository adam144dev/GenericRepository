using GenericRepositorySample.Models;
using System.Collections.Generic;
using System.Linq;

namespace GenericRepositorySample.test.Services
{
    public class FakeRepositoryData
    {
        private Category[] _categories;
        private Author[] _authors;
        private Book[] _books;


        public IQueryable <Category> Categories => _categories.AsQueryable();
        public IQueryable<Author> Authors => _authors.AsQueryable();
        public IQueryable<Book> Books => _books.AsQueryable();


        public FakeRepositoryData()
        {
            _categories = new Category[]
            {
                new Category { Id = 1, Name = "Books"},
                new Category { Id = 2, Name = "Super books"},
                new Category { Id = 3, Name = "Hyper books"},
                new Category { Id = 4, Name = "Zeta hyper books :-)"}
            };

            _authors = new Author[]
            {
                    new Author{
                        Id = 1,
                        FirstName = "John",
                        LastName = "Smith",
                        Biography = "..."
                    },
                    new Author{
                        Id = 2,
                        FirstName = "Jacek",
                        LastName = "Nowak",
                        Biography = "..."
                    },
            };

            _books = new Book[]
            {
                    new Book
                    {
                        Id = 1,
                        Title = "Superficial: More Adventures from the Andy Cohen Diaries",
                        Isbn = "Isbn11",
                        Synopsis = "Synopsis11",
                        Description = "Description11",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/614J%2B7vrGyL._SX355_BO1,204,203,200_.jpg",
                        ListPrice = 10M,
                        SalePrice = 9M,
                        Featured = true,
                        AuthorId = 1,
                        CategoryId = 1
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Last Girl Before Freeway: The Life, Loves, Losses, and Liberation of Joan Rivers",
                        Isbn = "Isbn12",
                        Synopsis = "Synopsis12",
                        Description = "Description12",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51HSPG4%2BvqL._SX321_BO1,204,203,200_.jpg",
                        ListPrice = 1.2M,
                        SalePrice = 1.0M,
                        Featured = false,
                        AuthorId = 1,
                        CategoryId = 1
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Small Great Things: A Novel",
                        Isbn = "Isbn21",
                        Synopsis = "Synopsis21",
                        Description = "Description21",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51MzOneN8rL._SX325_BO1,204,203,200_.jpg",
                        ListPrice = 2.1M,
                        SalePrice = 2.21M,
                        Featured = false,
                        AuthorId = 2,
                        CategoryId = 2
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "Born to Run",
                        Isbn = "Isbn22",
                        Synopsis = "Synopsis22",
                        Description = "Description22",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51hnB7FEgcL._SX327_BO1,204,203,200_.jpg",
                        ListPrice = 20M,
                        SalePrice = 17.99M,
                        Featured = true,
                        AuthorId = 2,
                        CategoryId = 3
                    }
            };

            foreach (var category in _categories)
                category.Books = GetBooksByCategory(_books, category.Id);

            foreach (var author in _authors)
                author.Books = GetBooksByAuthor(_books, author.Id);

            foreach (var book in _books)
            {
                book.Author = _authors.Single(a => a.Id == book.AuthorId);
                book.Category = _categories.Single(c => c.Id == book.CategoryId);
            }
        }

        // For Model.Category: public virtual ICollection<Book> Books { get; set; }
        private static IList<Book> GetBooksByCategory(IEnumerable<Book> books, int id)
        {
            var collection = new List<Book>();
            foreach (var book in books)
            {
                if (book.CategoryId == id)
                    collection.Add(book);
            }
            return collection;
        }

        // For Model.Author: public virtual ICollection<Book> Books { get; set; }
        private static IList<Book> GetBooksByAuthor(IEnumerable<Book> books, int id)
        {
            var collection = new List<Book>();
            foreach (var book in books)
            {
                if (book.AuthorId == id)
                    collection.Add(book);
            }
            return collection;
        }
    }
}
