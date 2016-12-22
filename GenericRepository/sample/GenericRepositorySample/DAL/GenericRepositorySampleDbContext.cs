using Microsoft.EntityFrameworkCore;
using GenericRepositorySample.Models;

namespace GenericRepositorySample.DAL
{
    public class GenericRepositorySampleDbContext : DbContext

    {
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
        //    optionsBuilder.UseSqlServer();
        //}
    }
}
