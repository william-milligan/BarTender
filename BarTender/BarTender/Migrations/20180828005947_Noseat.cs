using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BarTender.Migrations
{
    public partial class Noseat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customizations",
                columns: table => new
                {
                    CustomizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDouble = table.Column<bool>(nullable: false),
                    HasJuice = table.Column<bool>(nullable: false),
                    Vegan = table.Column<bool>(nullable: false),
                    LittleUmbrella = table.Column<bool>(nullable: false),
                    FrostyMug = table.Column<bool>(nullable: false),
                    SaltyRim = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customizations", x => x.CustomizationId);
                });

            migrationBuilder.CreateTable(
                name: "drinkOrders",
                columns: table => new
                {
                    DrinkOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrinkName = table.Column<string>(nullable: true),
                    TimeOrdered = table.Column<DateTime>(nullable: false),
                    CustomizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinkOrders", x => x.DrinkOrderId);
                    table.ForeignKey(
                        name: "FK_drinkOrders_customizations_CustomizationId",
                        column: x => x.CustomizationId,
                        principalTable: "customizations",
                        principalColumn: "CustomizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drinkOrders_CustomizationId",
                table: "drinkOrders",
                column: "CustomizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drinkOrders");

            migrationBuilder.DropTable(
                name: "customizations");
        }
    }
}
