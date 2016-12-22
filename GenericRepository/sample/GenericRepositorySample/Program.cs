using System;
using System.IO;
using GenericRepositorySample.DAL;
using GenericRepositorySample.Repositories;
using GenericRepositorySample.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositorySample
{
    public interface IApplication
    {
        void Run();
    }


    public class Program
    {
        public static IConfigurationRoot Configuration;

        public static void Main(string[] args)
        {
            Startup();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            Configure(serviceProvider, serviceProvider.GetService<ILoggerFactory>());

            var application = serviceProvider.GetService<IApplication>();
            application.Run();
        }
        
        public static void Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddDbContext<GenericRepositorySampleDbContext>(options =>
                 options.UseSqlServer(Configuration["Data:GenericRepositorySample:ConnectionString"]));

            services.AddTransient<IAuthorRepository, EFAuthorRepository>();
            services.AddTransient<IBookRepository, EFBookRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();

            services.AddTransient<IService, Service>();

            services.AddSingleton<IApplication, Application>();

        }

        public static void Configure(IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
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
    }
}
