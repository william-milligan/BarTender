using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarTender.Migrations
{
    public partial class CantSpell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrinkName",
                table: "drinkOrders");

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "drinkOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "drinkOrders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    DrinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrinkName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.DrinkId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drinkOrders_DrinkId",
                table: "drinkOrders",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_drinkOrders_Drink_DrinkId",
                table: "drinkOrders",
                column: "DrinkId",
                principalTable: "Drink",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drinkOrders_Drink_DrinkId",
                table: "drinkOrders");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_drinkOrders_DrinkId",
                table: "drinkOrders");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "drinkOrders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "drinkOrders");

            migrationBuilder.AddColumn<string>(
                name: "DrinkName",
                table: "drinkOrders",
                nullable: true);
        }
    }
}
