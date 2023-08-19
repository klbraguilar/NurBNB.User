using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Usuario.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingGuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "usuario",
                newName: "usuarioId");

            migrationBuilder.CreateTable(
                name: "huesped",
                columns: table => new
                {
                    guestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_huesped", x => x.guestId);
                    table.ForeignKey(
                        name: "FK_huesped_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_huesped_usuarioId",
                table: "huesped",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "huesped");

            migrationBuilder.RenameColumn(
                name: "usuarioId",
                table: "usuario",
                newName: "userId");
        }
    }
}
