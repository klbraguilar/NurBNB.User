using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Usuario.Infrastructure.Migrations
{
    public partial class CheckOutMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "checkout",
                columns: table => new
                {
                    outId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    calificacion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    guestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkout", x => x.outId);
                    table.ForeignKey(
                        name: "FK_checkout_huesped_guestId",
                        column: x => x.guestId,
                        principalTable: "huesped",
                        principalColumn: "guestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_checkout_guestId",
                table: "checkout",
                column: "guestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkout");
        }
    }
}
