using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DemoStore.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                    "ShoppingCartItemId",
                    "ShoppingCartItems",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                    "ProductId",
                    "Products",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                    "OrderId",
                    "Orders",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                    "OrderDetailId",
                    "OrderDetails",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                    "CategoryId",
                    "Categories",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "AspNetUserTokens",
                "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserTokens",
                "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                "FirstName",
                "AspNetUsers",
                "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "LastName",
                "AspNetUsers",
                "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                "ProfilePicture",
                "AspNetUsers",
                "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                "ProviderKey",
                "AspNetUserLogins",
                "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserLogins",
                "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<int>(
                    "Id",
                    "AspNetUserClaims",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                    "Id",
                    "AspNetRoleClaims",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "FirstName",
                "AspNetUsers");

            migrationBuilder.DropColumn(
                "LastName",
                "AspNetUsers");

            migrationBuilder.DropColumn(
                "ProfilePicture",
                "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                    "ShoppingCartItemId",
                    "ShoppingCartItems",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                    "ProductId",
                    "Products",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                    "OrderId",
                    "Orders",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                    "OrderDetailId",
                    "OrderDetails",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                    "CategoryId",
                    "Categories",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                "Name",
                "AspNetUserTokens",
                "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserTokens",
                "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                "ProviderKey",
                "AspNetUserLogins",
                "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                "LoginProvider",
                "AspNetUserLogins",
                "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                    "Id",
                    "AspNetUserClaims",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                    "Id",
                    "AspNetRoleClaims",
                    "integer",
                    nullable: false,
                    oldClrType: typeof(int),
                    oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}