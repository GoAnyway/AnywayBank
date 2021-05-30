using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class PasswordSecretMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordSecret",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSecret",
                table: "Users");
        }
    }
}
