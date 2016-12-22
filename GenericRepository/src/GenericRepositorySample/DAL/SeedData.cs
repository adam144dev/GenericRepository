using GenericRepositorySample.Models;
using System.Linq;

namespace GenericRepositorySample.DAL
{
    public static class SeedData
    {
        public static void EnsurePopulated(GenericRepositorySampleDbContext context)
        {
            if (context.Categories.Any())
                return;

            var categories = new Category[]
            {
                new Category { Name = "Books"},
                new Category { Name = "Super books"},
                new Category { Name = "Hyper books"},
                new Category { Name = "Zeta hyper books :-)"}
            };

            var authors = new Author[]
            {
                new Author{
                    FirstName = "John",
                    LastName = "Smith",
                    Biography = "..."
                },
                new Author{
                    FirstName = "Jacek",
                    LastName = "Nowak",
                    Biography = "..."
                },
            };

            var books = new Book[]
            {
                new Book
                {
                    Title = "Superficial: More Adventures from the Andy Cohen Diaries",
                    Isbn = "Isbn11",
                    Synopsis = "Synopsis11",
                    Description = "Description11",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/614J%2B7vrGyL._SX355_BO1,204,203,200_.jpg",
                    ListPrice = 10M,
                    SalePrice = 9M,
                    Featured = true,
                    Author = authors[0],
                    Category = categories[0]
                },
                new Book
                {
                    Title = "Last Girl Before Freeway: The Life, Loves, Losses, and Liberation of Joan Rivers",
                    Isbn = "Isbn12",
                    Synopsis = "Synopsis12",
                    Description = "Description12",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51HSPG4%2BvqL._SX321_BO1,204,203,200_.jpg",
                    ListPrice = 1.2M,
                    SalePrice = 1.0M,
                    Featured = false,
                    Author = authors[0],
                    Category = categories[0]
                },
                new Book
                {
                    Title = "Small Great Things: A Novel",
                    Isbn = "Isbn21",
                    Synopsis = "Synopsis21",
                    Description = "Description21",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51MzOneN8rL._SX325_BO1,204,203,200_.jpg",
                    ListPrice = 2.1M,
                    SalePrice = 2.21M,
                    Featured = false,
                    Author = authors[1],
                    Category = categories[1]
                },
                new Book
                {
                    Title = "Born to Run",
                    Isbn = "Isbn22",
                    Synopsis = "Synopsis22",
                    Description = "Description22",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51hnB7FEgcL._SX327_BO1,204,203,200_.jpg",
                    ListPrice = 20M,
                    SalePrice = 17.99M,
                    Featured = true,
                    Author = authors[1],
                    Category = categories[2]
                }
            };

            context.Categories.AddRange(categories);
            context.Authors.AddRange(authors);
            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
