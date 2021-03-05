using Microsoft.EntityFrameworkCore.Migrations;

namespace GameFacto.Data.Migrations
{
    public partial class IsDeletedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
