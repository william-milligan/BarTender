using Microsoft.EntityFrameworkCore.Migrations;

namespace BarTender.Migrations
{
    public partial class Whoops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_drinkOrders_customizations_CustomizationId",
                table: "drinkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_drinkOrders_drinks_DrinkId",
                table: "drinkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drinks",
                table: "drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_drinkOrders",
                table: "drinkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customizations",
                table: "customizations");

            migrationBuilder.RenameTable(
                name: "drinks",
                newName: "Drinks");

            migrationBuilder.RenameTable(
                name: "drinkOrders",
                newName: "DrinkOrders");

            migrationBuilder.RenameTable(
                name: "customizations",
                newName: "Customizations");

            migrationBuilder.RenameIndex(
                name: "IX_drinkOrders_DrinkId",
                table: "DrinkOrders",
                newName: "IX_DrinkOrders_DrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_drinkOrders_CustomizationId",
                table: "DrinkOrders",
                newName: "IX_DrinkOrders_CustomizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks",
                column: "DrinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrinkOrders",
                table: "DrinkOrders",
                column: "DrinkOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customizations",
                table: "Customizations",
                column: "CustomizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkOrders_Customizations_CustomizationId",
                table: "DrinkOrders",
                column: "CustomizationId",
                principalTable: "Customizations",
                principalColumn: "CustomizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrinkOrders_Drinks_DrinkId",
                table: "DrinkOrders",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrinkOrders_Customizations_CustomizationId",
                table: "DrinkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DrinkOrders_Drinks_DrinkId",
                table: "DrinkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrinkOrders",
                table: "DrinkOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customizations",
                table: "Customizations");

            migrationBuilder.RenameTable(
                name: "Drinks",
                newName: "drinks");

            migrationBuilder.RenameTable(
                name: "DrinkOrders",
                newName: "drinkOrders");

            migrationBuilder.RenameTable(
                name: "Customizations",
                newName: "customizations");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkOrders_DrinkId",
                table: "drinkOrders",
                newName: "IX_drinkOrders_DrinkId");

            migrationBuilder.RenameIndex(
                name: "IX_DrinkOrders_CustomizationId",
                table: "drinkOrders",
                newName: "IX_drinkOrders_CustomizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drinks",
                table: "drinks",
                column: "DrinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_drinkOrders",
                table: "drinkOrders",
                column: "DrinkOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customizations",
                table: "customizations",
                column: "CustomizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_drinkOrders_customizations_CustomizationId",
                table: "drinkOrders",
                column: "CustomizationId",
                principalTable: "customizations",
                principalColumn: "CustomizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_drinkOrders_drinks_DrinkId",
                table: "drinkOrders",
                column: "DrinkId",
                principalTable: "drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
