using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Schlupy.WebAPI.Migrations
{
    public partial class _1031 : Migration
    {
        #region Methods

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClockEntry");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClockEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DateEnded = table.Column<DateTime>(nullable: true),
                    DateStarted = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClockEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClockEntry_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClockEntry_UserId",
                table: "ClockEntry",
                column: "UserId");
        }

        #endregion Methods
    }
}