using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GaidoSystem.Migrations
{
    public partial class leo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnualidadER",
                columns: table => new
                {
                    AnualidadERId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<DateTime>(nullable: false),
                    Notas = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnualidadER", x => x.AnualidadERId);
                });

            migrationBuilder.CreateTable(
                name: "ModeloProyeccion",
                columns: table => new
                {
                    ModeloProyeccionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ModVentasNetas = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ModCostosVentas = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ModGastosAdmin = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ModGastosVentas = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ModGastosOperativos = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ModOtrosGastos = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloProyeccion", x => x.ModeloProyeccionId);
                });

            migrationBuilder.CreateTable(
                name: "HistorialER",
                columns: table => new
                {
                    HistorialERId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    VentasNetas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostosVentas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GastosAdmin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GastosVentas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GastosOperativos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtrosGastos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnualidadERId = table.Column<int>(nullable: false),
                    ModeloProyeccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialER", x => x.HistorialERId);
                    table.ForeignKey(
                        name: "FK_HistorialER_AnualidadER_AnualidadERId",
                        column: x => x.AnualidadERId,
                        principalTable: "AnualidadER",
                        principalColumn: "AnualidadERId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proyecciones",
                columns: table => new
                {
                    ProyeccionesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ProVentasNetas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProCostosVentas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProGastosAdmin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProGastosVentas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProGastosOperativos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProOtrosGastos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModeloProyeccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecciones", x => x.ProyeccionesId);
                    table.ForeignKey(
                        name: "FK_Proyecciones_ModeloProyeccion_ModeloProyeccionId",
                        column: x => x.ModeloProyeccionId,
                        principalTable: "ModeloProyeccion",
                        principalColumn: "ModeloProyeccionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialER_AnualidadERId",
                table: "HistorialER",
                column: "AnualidadERId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecciones_ModeloProyeccionId",
                table: "Proyecciones",
                column: "ModeloProyeccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialER");

            migrationBuilder.DropTable(
                name: "Proyecciones");

            migrationBuilder.DropTable(
                name: "AnualidadER");

            migrationBuilder.DropTable(
                name: "ModeloProyeccion");
        }
    }
}
