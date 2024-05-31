using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VineyardSite.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInventoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Wines_WineId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Id_WineId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "AlcoholContent",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Wines");

            migrationBuilder.RenameColumn(
                name: "WineId",
                table: "Inventory",
                newName: "WineVariantId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_WineId",
                table: "Inventory",
                newName: "IX_Inventory_WineVariantId");

            migrationBuilder.CreateTable(
                name: "WineVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WineId = table.Column<int>(type: "int", nullable: false),
                    AlcoholContent = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineVariants_Wines_WineId",
                        column: x => x.WineId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WineVariants_WineId",
                table: "WineVariants",
                column: "WineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_WineVariants_WineVariantId",
                table: "Inventory",
                column: "WineVariantId",
                principalTable: "WineVariants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_WineVariants_WineVariantId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "WineVariants");

            migrationBuilder.RenameColumn(
                name: "WineVariantId",
                table: "Inventory",
                newName: "WineId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_WineVariantId",
                table: "Inventory",
                newName: "IX_Inventory_WineId");

            migrationBuilder.AddColumn<double>(
                name: "AlcoholContent",
                table: "Wines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Wines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Wines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Id_WineId",
                table: "Inventory",
                columns: new[] { "Id", "WineId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Wines_WineId",
                table: "Inventory",
                column: "WineId",
                principalTable: "Wines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
