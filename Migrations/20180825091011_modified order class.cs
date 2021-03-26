using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoStore.Migrations
{
    public partial class modifiedorderclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "AddressLine2",
                "Orders");

            migrationBuilder.DropColumn(
                "Country",
                "Orders");

            migrationBuilder.DropColumn(
                "FirstName",
                "Orders");

            migrationBuilder.DropColumn(
                "State",
                "Orders");

            migrationBuilder.RenameColumn(
                "LastName",
                "Orders",
                "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                "Name",
                "Orders",
                "LastName");

            migrationBuilder.AddColumn<string>(
                "AddressLine2",
                "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Country",
                "Orders",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                "FirstName",
                "Orders",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                "State",
                "Orders",
                maxLength: 20,
                nullable: true);
        }
    }
}