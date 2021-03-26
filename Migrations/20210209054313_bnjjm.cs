using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class bnjjm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Products_Suppliers_SupplierId",
                "Products");

            migrationBuilder.AlterColumn<int>(
                "SupplierId",
                "Products",
                "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                "FK_Products_Suppliers_SupplierId",
                "Products",
                "SupplierId",
                "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Products_Suppliers_SupplierId",
                "Products");

            migrationBuilder.AlterColumn<int>(
                "SupplierId",
                "Products",
                "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                "FK_Products_Suppliers_SupplierId",
                "Products",
                "SupplierId",
                "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}