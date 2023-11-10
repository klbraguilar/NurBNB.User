﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NurBNB.Usuario.Infrastructure.Migrations
{
    public partial class AddingReservaID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "reservaId",
                table: "checkin",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservaId",
                table: "checkin");
        }
    }
}
