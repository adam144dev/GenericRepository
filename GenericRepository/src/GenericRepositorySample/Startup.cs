using System;
using GenericRepositorySample.DAL;
using GenericRepositorySample.Repositories;
using GenericRepositorySample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GenericRepositorySample
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(string basePath)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLogging();

            services.AddDbContext<GenericRepositorySampleDbContext>(options =>
                 options.UseSqlServer(Configuration["Data:GenericRepositorySample:ConnectionString"]));

            services.AddTransient<IAuthorRepository, EFAuthorRepository>();
            services.AddTransient<IBookRepository, EFBookRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();

            services.AddTransient<IService, Service>();

        }

        public void Configure(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            SeedData.EnsurePopulated(serviceProvider.GetService<GenericRepositorySampleDbContext>());

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
            //    cfg.CreateMap<Author, AuthorViewModel>().ReverseMap();
            //    cfg.CreateMap<Book, BookViewModel>().ReverseMap();
            //});
        }

        public void Run(IServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService<IService>();

            Console.WriteLine("GetAllCategories");
            foreach (var c in service.GetAllCategories())
                Console.WriteLine("\tc");
        }
    }
}
