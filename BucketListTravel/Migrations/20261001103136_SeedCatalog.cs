using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BucketListTravel.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beach & Islands" },
                    { 2, "Nature & Wildlife" },
                    { 3, "Adventure" },
                    { 4, "Culture & History" },
                    { 5, "Cities & Food" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Greece", "Whitewashed villages, volcanic beaches, and spectacular sunsets over the Aegean Sea.", "https://images.unsplash.com/photo-1570077188670-e3a8d69ac5ff", "Santorini" },
                    { 2, 1, "French Polynesia", "A turquoise lagoon surrounded by coral reefs and lush volcanic peaks.", "https://images.unsplash.com/photo-1507525428034-b723cf961d3e", "Bora Bora" },
                    { 3, 1, "Italy", "Dramatic coastal cliffs, colorful villages, and clear Mediterranean waters.", "https://images.unsplash.com/photo-1533105079780-92b9be482077", "Amalfi Coast" },
                    { 4, 2, "Canada", "Glacial lakes, alpine trails, and mountain scenery in the Canadian Rockies.", "https://images.unsplash.com/photo-1503614472-8c93d56e92ce", "Banff National Park" },
                    { 5, 2, "Tanzania", "Vast plains and unforgettable wildlife encounters during the great migration.", "https://images.unsplash.com/photo-1516426122078-c23e76319801", "Serengeti National Park" },
                    { 6, 2, "Ecuador", "Unique wildlife, volcanic landscapes, and extraordinary snorkeling opportunities.", "https://images.unsplash.com/photo-1544551763-46a013bb70d5", "Galápagos Islands" },
                    { 7, 3, "Argentina", "Remote wilderness with glaciers, granite peaks, and world-class trekking routes.", "https://images.unsplash.com/photo-1530789253388-582c481c54b0", "Patagonia" },
                    { 8, 3, "Switzerland", "An alpine base for paragliding, hiking, skiing, and breathtaking mountain views.", "https://images.unsplash.com/photo-1531366936337-7c912a4589a7", "Interlaken" },
                    { 9, 3, "New Zealand", "The adventure capital of New Zealand, surrounded by lakes and dramatic peaks.", "https://images.unsplash.com/photo-1469521669194-babb45599def", "Queenstown" },
                    { 10, 4, "Japan", "Historic temples, traditional gardens, and seasonal Japanese culture.", "https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e", "Kyoto" },
                    { 11, 4, "Jordan", "An ancient city carved into rose-colored cliffs and reached through the Siq.", "https://images.unsplash.com/photo-1548786811-dd6e453ccca7", "Petra" },
                    { 12, 4, "Peru", "A remarkable Inca citadel set high in the Andes above the Sacred Valley.", "https://images.unsplash.com/photo-1526392060635-9d6019884377", "Machu Picchu" },
                    { 13, 5, "Spain", "Gaudí architecture, lively neighborhoods, Mediterranean beaches, and tapas.", "https://images.unsplash.com/photo-1539037116277-4db20889f2d4", "Barcelona" },
                    { 14, 5, "Türkiye", "A crossroads of continents known for its markets, mosques, and rich cuisine.", "https://images.unsplash.com/photo-1524231757912-21f4fe3a7200", "Istanbul" },
                    { 15, 5, "United States", "Distinctive Creole food, jazz, and historic architecture along the Mississippi.", "https://images.unsplash.com/photo-1548013146-72479768bada", "New Orleans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
