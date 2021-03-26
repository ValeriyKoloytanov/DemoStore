using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class byte_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "ImageUrl",
                "Products",
                "ImageUrl");

            migrationBuilder.AddColumn<byte[]>(
                "Image",
                "Products",
                "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Image",
                "Products");

            migrationBuilder.RenameColumn(
                "ImageUrl",
                "Products",
                "ImageUrl");
        }
    }
}