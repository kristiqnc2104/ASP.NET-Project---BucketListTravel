using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BucketListTravel.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToBucketListEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BucketListEntries_DestinationId",
                table: "BucketListEntries");

            migrationBuilder.CreateIndex(
                name: "IX_BucketListEntries_DestinationId",
                table: "BucketListEntries",
                column: "DestinationId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BucketListEntries_DestinationId",
                table: "BucketListEntries");

            migrationBuilder.CreateIndex(
                name: "IX_BucketListEntries_DestinationId",
                table: "BucketListEntries",
                column: "DestinationId");
        }
    }
}
