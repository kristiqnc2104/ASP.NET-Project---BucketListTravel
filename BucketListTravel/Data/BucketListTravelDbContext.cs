using BucketListTravel.Data.Configurations;
using BucketListTravel.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Data
{
    public class BucketListTravelDbContext : IdentityDbContext<IdentityUser>
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

            modelBuilder.Entity<BucketListEntry>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BucketListEntry>()
                .HasIndex(e => new { e.UserId, e.DestinationId })
                .IsUnique();

            modelBuilder.Entity<Destination>()
                .HasOne(d => d.Owner)
                .WithMany()
                .HasForeignKey(d => d.OwnerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Destination>()
                .HasQueryFilter(destination => !destination.IsDeleted);

            modelBuilder.Entity<BucketListEntry>()
                .HasQueryFilter(e => !e.Destination.IsDeleted);
        }
    }
}
