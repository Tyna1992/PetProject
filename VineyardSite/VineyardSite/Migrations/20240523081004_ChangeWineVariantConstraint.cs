using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VineyardSite.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWineVariantConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WineVariants_WineId",
                table: "WineVariants");

            migrationBuilder.CreateIndex(
                name: "IX_WineVariants_WineId_Year_Price_AlcoholContent",
                table: "WineVariants",
                columns: new[] { "WineId", "Year", "Price", "AlcoholContent" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WineVariants_WineId_Year_Price_AlcoholContent",
                table: "WineVariants");

            migrationBuilder.CreateIndex(
                name: "IX_WineVariants_WineId",
                table: "WineVariants",
                column: "WineId");
        }
    }
}
