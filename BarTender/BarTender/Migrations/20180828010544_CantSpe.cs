using Microsoft.EntityFrameworkCore.Migrations;

namespace BarTender.Migrations
{
    public partial class CantSpe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drinkOrders_Drink_DrinkId",
                table: "drinkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drink",
                table: "Drink");

            migrationBuilder.RenameTable(
                name: "Drink",
                newName: "drinks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drinks",
                table: "drinks",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_drinkOrders_drinks_DrinkId",
                table: "drinkOrders",
                column: "DrinkId",
                principalTable: "drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drinkOrders_drinks_DrinkId",
                table: "drinkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drinks",
                table: "drinks");

            migrationBuilder.RenameTable(
                name: "drinks",
                newName: "Drink");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drink",
                table: "Drink",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_drinkOrders_Drink_DrinkId",
                table: "drinkOrders",
                column: "DrinkId",
                principalTable: "Drink",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
