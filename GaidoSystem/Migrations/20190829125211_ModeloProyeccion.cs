using Microsoft.EntityFrameworkCore.Migrations;

namespace GaidoSystem.Migrations
{
    public partial class ModeloProyeccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Utilidad",
                table: "ModeloProyeccion",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Utilidad",
                table: "ModeloProyeccion");
        }
    }
}
