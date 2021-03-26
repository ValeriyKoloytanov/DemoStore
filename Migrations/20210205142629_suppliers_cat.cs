using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class suppliers_cat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "supplierId",
                "Products",
                "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Products_supplierId",
                "Products",
                "supplierId");

            migrationBuilder.AddForeignKey(
                "FK_Products_Suppliers_supplierId",
                "Products",
                "supplierId",
                "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Products_Suppliers_supplierId",
                "Products");

            migrationBuilder.DropIndex(
                "IX_Products_supplierId",
                "Products");

            migrationBuilder.DropColumn(
                "supplierId",
                "Products");
        }
    }
}