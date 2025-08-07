using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using NetCoreMicroservice.Catalog.API.Features.Categories;
using NetCoreMicroservice.Catalog.API.Features.Courses;
using System.Reflection;

namespace NetCoreMicroservice.Catalog.API.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext(option)
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public static AppDbContext Create(IMongoDatabase database)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(database.Client,database.DatabaseNamespace.DatabaseName);

            return new AppDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
