﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GaidoSystem.Migrations
{
    public partial class IR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IR",
                table: "HistorialER",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UtilidadNeta",
                table: "HistorialER",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IR",
                table: "HistorialER");

            migrationBuilder.DropColumn(
                name: "UtilidadNeta",
                table: "HistorialER");
        }
    }
}
