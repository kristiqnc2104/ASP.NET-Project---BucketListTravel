using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BucketListTravel.Migrations
{
    /// <inheritdoc />
    public partial class ReducingNumberOfDestinationsInCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, "Canada", "Glacial lakes, alpine trails, and mountain scenery in the Canadian Rockies.", "https://images.unsplash.com/photo-1503614472-8c93d56e92ce", "Banff National Park" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { "Ecuador", "Unique wildlife, volcanic landscapes, and extraordinary snorkeling opportunities.", "https://images.unsplash.com/photo-1544551763-46a013bb70d5", "Galápagos Islands" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, "Switzerland", "An alpine base for paragliding, hiking, skiing, and breathtaking mountain views.", "https://images.unsplash.com/photo-1531366936337-7c912a4589a7", "Interlaken" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, "New Zealand", "The adventure capital of New Zealand, surrounded by lakes and dramatic peaks.", "https://images.unsplash.com/photo-1469521669194-babb45599def", "Queenstown" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 4, "Japan", "Historic temples, traditional gardens, and seasonal Japanese culture.", "https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e", "Kyoto" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 4, "Peru", "A remarkable Inca citadel set high in the Andes above the Sacred Valley.", "https://images.unsplash.com/photo-1526392060635-9d6019884377", "Machu Picchu" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 5, "Spain", "Gaudí architecture, lively neighborhoods, Mediterranean beaches, and tapas.", "https://images.unsplash.com/photo-1539037116277-4db20889f2d4", "Barcelona" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 5, "Türkiye", "A crossroads of continents known for its markets, mosques, and rich cuisine.", "https://images.unsplash.com/photo-1524231757912-21f4fe3a7200", "Istanbul" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 1, "Italy", "Dramatic coastal cliffs, colorful villages, and clear Mediterranean waters.", "https://images.unsplash.com/photo-1533105079780-92b9be482077", "Amalfi Coast" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { "Canada", "Glacial lakes, alpine trails, and mountain scenery in the Canadian Rockies.", "https://images.unsplash.com/photo-1503614472-8c93d56e92ce", "Banff National Park" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, "Tanzania", "Vast plains and unforgettable wildlife encounters during the great migration.", "https://images.unsplash.com/photo-1516426122078-c23e76319801", "Serengeti National Park" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 2, "Ecuador", "Unique wildlife, volcanic landscapes, and extraordinary snorkeling opportunities.", "https://images.unsplash.com/photo-1544551763-46a013bb70d5", "Galápagos Islands" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, "Argentina", "Remote wilderness with glaciers, granite peaks, and world-class trekking routes.", "https://images.unsplash.com/photo-1530789253388-582c481c54b0", "Patagonia" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, "Switzerland", "An alpine base for paragliding, hiking, skiing, and breathtaking mountain views.", "https://images.unsplash.com/photo-1531366936337-7c912a4589a7", "Interlaken" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 3, "New Zealand", "The adventure capital of New Zealand, surrounded by lakes and dramatic peaks.", "https://images.unsplash.com/photo-1469521669194-babb45599def", "Queenstown" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Country", "Description", "ImageUrl", "Name" },
                values: new object[] { 4, "Japan", "Historic temples, traditional gardens, and seasonal Japanese culture.", "https://images.unsplash.com/photo-1493976040374-85c8e12f0c0e", "Kyoto" });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "CategoryId", "Country", "Description", "ImageUrl", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 11, 4, "Jordan", "An ancient city carved into rose-colored cliffs and reached through the Siq.", "https://images.unsplash.com/photo-1548786811-dd6e453ccca7", "Petra", null },
                    { 12, 4, "Peru", "A remarkable Inca citadel set high in the Andes above the Sacred Valley.", "https://images.unsplash.com/photo-1526392060635-9d6019884377", "Machu Picchu", null },
                    { 13, 5, "Spain", "Gaudí architecture, lively neighborhoods, Mediterranean beaches, and tapas.", "https://images.unsplash.com/photo-1539037116277-4db20889f2d4", "Barcelona", null },
                    { 14, 5, "Türkiye", "A crossroads of continents known for its markets, mosques, and rich cuisine.", "https://images.unsplash.com/photo-1524231757912-21f4fe3a7200", "Istanbul", null },
                    { 15, 5, "United States", "Distinctive Creole food, jazz, and historic architecture along the Mississippi.", "https://images.unsplash.com/photo-1548013146-72479768bada", "New Orleans", null }
                });
        }
    }
}
