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

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var catalogSeedConfiguration = new CatalogSeedConfiguration();
            modelBuilder.ApplyConfiguration<Category>(catalogSeedConfiguration);
            modelBuilder.ApplyConfiguration<Destination>(catalogSeedConfiguration);

            modelBuilder.Entity<BucketListEntry>()
                .HasOne(e => e.Destination)
                .WithMany(d => d.BucketListEntries)
                .HasForeignKey(e => e.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
