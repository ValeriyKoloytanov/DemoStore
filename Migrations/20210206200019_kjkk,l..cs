using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class kjkkl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Products_Suppliers_SuppliersId",
                "Products");

            migrationBuilder.RenameColumn(
                "SuppliersId",
                "Products",
                "SupplierId");

            migrationBuilder.RenameIndex(
                "IX_Products_SuppliersId",
                table: "Products",
                newName: "IX_Products_SupplierId");

            migrationBuilder.AddForeignKey(
                "FK_Products_Suppliers_SupplierId",
                "Products",
                "SupplierId",
                "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Products_Suppliers_SupplierId",
                "Products");

            migrationBuilder.RenameColumn(
                "SupplierId",
                "Products",
                "SuppliersId");

            migrationBuilder.RenameIndex(
                "IX_Products_SupplierId",
                table: "Products",
                newName: "IX_Products_SuppliersId");

            migrationBuilder.AddForeignKey(
                "FK_Products_Suppliers_SuppliersId",
                "Products",
                "SuppliersId",
                "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}