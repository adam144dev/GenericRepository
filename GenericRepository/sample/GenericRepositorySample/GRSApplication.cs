using System;
using CollectionsExtensions;
using GenericRepositorySample.Models;
using GenericRepositorySample.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GenericRepositorySample
{
    public class GRSApplication : IApplication
    {
        private readonly IService service;

        public GRSApplication(IServiceProvider serviceProvider)
        {
            service = serviceProvider.GetService<IService>();
        }
      
        public void Run()
        {
            Console.WriteLine($"\nGetAllCategories");
            service.GetAllCategories().ForEach(WriteCategory);

            Console.WriteLine($"\nGetAllAuthors");
            service.GetAllAuthors().ForEach(WriteAuthor);

            Console.WriteLine($"\nGetAllBooks");
            service.GetAllBooks().ForEach(WriteBook);

            Console.WriteLine($"\nWriteGetBooksByCategoryId(count:{service.GetAllCategories().Count})");
            service.GetAllCategories().ForEach(e => WriteGetBooksByCategoryId(e.Id));

            Console.WriteLine($"\nWriteGetBookById");
            service.GetAllBooks().ForEach(e => WriteGetBookById(e.Id));
        }

        private void WriteCategory(Category e)
            => Console.WriteLine($"\tId:{e.Id} Name:{e.Name}");

        private void WriteAuthor(Author e)
            => Console.WriteLine($"\tId:{e.Id}, FirstName:{e.FirstName}, LastName:{e.LastName}, FullName:{e.FullName}, , Biography:{e.Biography}");

        private void WriteGetBooksByCategoryId(int id)
        {
            Console.WriteLine($"\nGetBooksByCategoryId:{id}");
            service.GetBooksByCategoryId(id).ForEach(WriteBook);
        }

        private void WriteGetBookById(int id)
            => WriteBook(service.GetBookById(id));

        private void WriteBook(Book e)
            => Console.WriteLine($"\tId:{e.Id}, Title:'{e.Title}', AuthorId:{e.AuthorId}, Author:{e.Author.FullName}, CategoryId:{e.CategoryId}, Category:{e.Category.Name}, Featured:{e.Featured}"); // tbd...

    }

}
