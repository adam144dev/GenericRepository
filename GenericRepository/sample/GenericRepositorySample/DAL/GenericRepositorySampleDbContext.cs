using Microsoft.EntityFrameworkCore;
using GenericRepositorySample.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace GenericRepositorySample.DAL
{
    public class GenericRepositorySampleDbContext : DbContext
    {
        public const string ConfigurationPath = "Data:GenericRepositorySample:ConnectionString";

        public GenericRepositorySampleDbContext(DbContextOptions<GenericRepositorySampleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(...);
        //}
    }

    // For EF Migrations:
    public class GenericRepositorySampleDbContextFactory : IDbContextFactory<GenericRepositorySampleDbContext>
    {
        public GenericRepositorySampleDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(options.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<GenericRepositorySampleDbContext>();
            optionsBuilder.UseSqlServer(configuration[GenericRepositorySampleDbContext.ConfigurationPath]);

            return new GenericRepositorySampleDbContext(optionsBuilder.Options);
        }
    }
}
