using System.IO;
using GenericRepositorySample.DAL;
using GenericRepositorySample.Repositories;
using GenericRepositorySample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GenericRepositorySample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sample = new Startup(Directory.GetCurrentDirectory());

            var serviceCollection = new ServiceCollection();
            sample.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            sample.Configure(serviceProvider.GetService<ILoggerFactory>());

            sample.Run(serviceProvider.GetService<IService>());
        }
    }


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

        public void Configure(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //SeedData.EnsurePopulated(app);

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
            //    cfg.CreateMap<Author, AuthorViewModel>().ReverseMap();
            //    cfg.CreateMap<Book, BookViewModel>().ReverseMap();
            //});
        }

        public void Run(IService service)
        {
            //IService service = new Service(
            //        new EFCategoryRepository(dbContext),
            //        new EFAuthorRepository(dbContext),
            //        new EFBookRepository(dbContext)
            //    );
        }
    }
}
