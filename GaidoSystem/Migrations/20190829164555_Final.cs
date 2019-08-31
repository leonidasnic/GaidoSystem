using Microsoft.EntityFrameworkCore.Migrations;

namespace GaidoSystem.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Utilidad",
                table: "ModeloProyeccion",
                newName: "ModUtilidadNeta");

            migrationBuilder.AddColumn<decimal>(
                name: "proIR",
                table: "Proyecciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "proUtilidad",
                table: "Proyecciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "proUtilidadNeta",
                table: "Proyecciones",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ModIR",
                table: "ModeloProyeccion",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ModUtilidad",
                table: "ModeloProyeccion",
                type: "decimal(4,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "proIR",
                table: "Proyecciones");

            migrationBuilder.DropColumn(
                name: "proUtilidad",
                table: "Proyecciones");

            migrationBuilder.DropColumn(
                name: "proUtilidadNeta",
                table: "Proyecciones");

            migrationBuilder.DropColumn(
                name: "ModIR",
                table: "ModeloProyeccion");

            migrationBuilder.DropColumn(
                name: "ModUtilidad",
                table: "ModeloProyeccion");

            migrationBuilder.RenameColumn(
                name: "ModUtilidadNeta",
                table: "ModeloProyeccion",
                newName: "Utilidad");
        }
    }
}
