using BucketListTravel.Data.Configurations;
using BucketListTravel.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Data
{
    public class BucketListTravelDbContext : DbContext
    {
        public BucketListTravelDbContext(DbContextOptions<BucketListTravelDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<BucketListEntry> BucketListEntries { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var catalogSeedConfiguration = new CatalogSeedConfiguration();
            modelBuilder.ApplyConfiguration<Category>(catalogSeedConfiguration);
            modelBuilder.ApplyConfiguration<Destination>(catalogSeedConfiguration);
        }
    }
}
