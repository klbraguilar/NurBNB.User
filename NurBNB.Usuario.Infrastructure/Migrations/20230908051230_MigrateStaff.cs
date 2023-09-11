using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Usuario.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrateStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "staff",
                columns: table => new
                {
                    staffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staff", x => x.staffId);
                    table.ForeignKey(
                        name: "FK_staff_usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "usuario",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_staff_usuarioId",
                table: "staff",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "staff");
        }
    }
}
