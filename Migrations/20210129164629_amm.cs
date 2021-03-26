using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class amm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "Ammaval",
                "Products",
                "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Ammaval",
                "Products");
        }
    }
}