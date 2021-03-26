using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class test_pro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                "Properities",
                "Products",
                "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Properities",
                "Products");
        }
    }
}