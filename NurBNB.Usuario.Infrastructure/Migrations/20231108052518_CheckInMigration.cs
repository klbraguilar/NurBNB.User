using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Usuario.Infrastructure.Migrations
{
    public partial class CheckInMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "checkin",
                columns: table => new
                {
                    inId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    contacto = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    fechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    guestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkin", x => x.inId);
                    table.ForeignKey(
                        name: "FK_checkin_huesped_guestId",
                        column: x => x.guestId,
                        principalTable: "huesped",
                        principalColumn: "guestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_checkin_guestId",
                table: "checkin",
                column: "guestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkin");
        }
    }
}
