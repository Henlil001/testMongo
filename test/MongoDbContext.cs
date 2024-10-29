using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using test.Models;

namespace test
{
    public class MongoDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Test> Test { get; init; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Test>()
            //  .ToCollection("Test");
        }
    }
}
