using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;

namespace NetCoreMicroservice.Discount.API.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext(option)
    {

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
