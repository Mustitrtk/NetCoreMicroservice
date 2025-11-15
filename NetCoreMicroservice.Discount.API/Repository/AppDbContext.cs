using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using NetCoreMicroservice.Discount.API.Features.Discount;
using System.Reflection;

namespace NetCoreMicroservice.Discount.API.Repository
{
    public class AppDbContext(DbContextOptions<AppDbContext> option) : DbContext(option)
    {
        public DbSet<DiscountEntity> Discounts { get; set; }
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
