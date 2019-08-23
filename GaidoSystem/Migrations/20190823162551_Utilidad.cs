using Microsoft.EntityFrameworkCore.Migrations;

namespace GaidoSystem.Migrations
{
    public partial class Utilidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Utilidad",
                table: "HistorialER",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Utilidad",
                table: "HistorialER");
        }
    }
}
