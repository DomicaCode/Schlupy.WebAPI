using Microsoft.EntityFrameworkCore.Migrations;

namespace Schlupy.WebAPI.Migrations
{
    public partial class _1032 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRunning",
                table: "ClockEntry",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRunning",
                table: "ClockEntry");
        }
    }
}
