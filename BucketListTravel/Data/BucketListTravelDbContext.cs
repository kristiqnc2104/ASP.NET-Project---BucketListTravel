using BucketListTravel.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        
        
    }
}
