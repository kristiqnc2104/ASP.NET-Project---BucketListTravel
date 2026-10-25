using BucketListTravel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BucketListTravel.Data.Configurations
{
    public sealed class CatalogSeedConfiguration :
        IEntityTypeConfiguration<Category>,
        IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = 1, Name = "Beach & Islands" },
                new Category { Id = 2, Name = "Nature & Wildlife" },
                new Category { Id = 3, Name = "Adventure" },
                new Category { Id = 4, Name = "Culture & History" },
                new Category { Id = 5, Name = "Cities & Food" });
        }

        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            //Sample data for destinations to show that the catalog is working
            builder.HasData(
                new Destination
                {
                    Id = 1,
                    Name = "Santorini",
                    Country = "Greece",
                    Description = "Whitewashed villages, volcanic beaches, and spectacular sunsets over the Aegean Sea.",
                    ImageUrl = "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff",
                    CategoryId = 1
                },
                new Destination
                {
                    Id = 2,
                    Name = "Bora Bora",
                    Country = "French Polynesia",
                    Description = "A turquoise lagoon surrounded by coral reefs and lush volcanic peaks.",
                    ImageUrl = "https://images.unsplash.com/photo-1507525428034-b723cf961d3e",
                    CategoryId = 1
                },
                new Destination
                {
                    Id = 3,
                    Name = "Banff National Park",
                    Country = "Canada",
                    Description = "Glacial lakes, alpine trails, and mountain scenery in the Canadian Rockies.",
                    ImageUrl = "https://images.unsplash.com/photo-1503614472-8c93d56e92ce",
                    CategoryId = 2
                },
                new Destination
                {
                    Id = 4,
                    Name = "Galápagos Islands",
                    Country = "Ecuador",
                    Description = "Unique wildlife, volcanic landscapes, and extraordinary snorkeling opportunities.",
                    ImageUrl = "https://images.unsplash.com/photo-1544551763-46a013bb70d5",
                    CategoryId = 2
                },
                new Destination
                {
                    Id = 5,
                    Name = "Interlaken",
                    Country = "Switzerland",
                    Description = "An alpine base for paragliding, hiking, skiing, and breathtaking mountain views.",
                    ImageUrl = "https://images.unsplash.com/photo-1531366936337-7c912a4589a7",
                    CategoryId = 3
                },
                new Destination
                {
                    Id = 6,
                    Name = "Queenstown",
                    Country = "New Zealand",
                    Description = "The adventure capital of New Zealand, surrounded by lakes and dramatic peaks.",
                    ImageUrl = "https://images.unsplash.com/photo-1469521669194-babb45599def",
                    CategoryId = 3
                },
                new Destination
                {
                    Id = 7,
                    Name = "Kyoto",
                    Country = "Japan",
                    Description = "Historic temples, traditional gardens, and seasonal Japanese culture.",
                    ImageUrl = "https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e",
                    CategoryId = 4
                },
                new Destination
                {
                    Id = 8,
                    Name = "Machu Picchu",
                    Country = "Peru",
                    Description = "A remarkable Inca citadel set high in the Andes above the Sacred Valley.",
                    ImageUrl = "https://images.unsplash.com/photo-1526392060635-9d6019884377",
                    CategoryId = 4
                },
                new Destination
                {
                    Id = 9,
                    Name = "Barcelona",
                    Country = "Spain",
                    Description = "Gaudí architecture, lively neighborhoods, Mediterranean beaches, and tapas.",
                    ImageUrl = "https://images.unsplash.com/photo-1539037116277-4db20889f2d4",
                    CategoryId = 5
                },
                new Destination
                {
                    Id = 10,
                    Name = "Istanbul",
                    Country = "Türkiye",
                    Description = "A crossroads of continents known for its markets, mosques, and rich cuisine.",
                    ImageUrl = "https://images.unsplash.com/photo-1524231757912-21f4fe3a7200",
                    CategoryId = 5
                });
        }
    }
}
