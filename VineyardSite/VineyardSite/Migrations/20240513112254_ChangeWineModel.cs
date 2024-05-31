using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VineyardSite.Migrations
{
    /// <inheritdoc />
    public partial class ChangeWineModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sweetness",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sweetness",
                table: "Wines");
        }
    }
}
