using Microsoft.EntityFrameworkCore.Migrations;

namespace GaidoSystem.Migrations
{
    public partial class DropAnualidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialER_AnualidadER_AnualidadERId",
                table: "HistorialER");

            migrationBuilder.DropIndex(
                name: "IX_HistorialER_AnualidadERId",
                table: "HistorialER");

            migrationBuilder.DropColumn(
                name: "AnualidadERId",
                table: "HistorialER");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialER_ModeloProyeccionId",
                table: "HistorialER",
                column: "ModeloProyeccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialER_ModeloProyeccion_ModeloProyeccionId",
                table: "HistorialER",
                column: "ModeloProyeccionId",
                principalTable: "ModeloProyeccion",
                principalColumn: "ModeloProyeccionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialER_ModeloProyeccion_ModeloProyeccionId",
                table: "HistorialER");

            migrationBuilder.DropIndex(
                name: "IX_HistorialER_ModeloProyeccionId",
                table: "HistorialER");

            migrationBuilder.AddColumn<int>(
                name: "AnualidadERId",
                table: "HistorialER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialER_AnualidadERId",
                table: "HistorialER",
                column: "AnualidadERId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialER_AnualidadER_AnualidadERId",
                table: "HistorialER",
                column: "AnualidadERId",
                principalTable: "AnualidadER",
                principalColumn: "AnualidadERId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
