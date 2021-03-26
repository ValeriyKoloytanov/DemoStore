using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class jnjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Products_Suppliers_supplierId",
                "Products");

            migrationBuilder.RenameColumn(
                "supplierId",
                "Products",
                "SuppliersId");

            migrationBuilder.RenameIndex(
                "IX_Products_supplierId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Products_Suppliers_SuppliersId",
                "Products");

            migrationBuilder.RenameColumn(
                "SuppliersId",
                "Products",
                "supplierId");

            migrationBuilder.RenameIndex(
                "IX_Products_SuppliersId",
                table: "Products",
                newName: "IX_Products_supplierId");

            migrationBuilder.AddForeignKey(
                "FK_Products_Suppliers_supplierId",
                "Products",
                "supplierId",
                "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}