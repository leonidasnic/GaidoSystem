using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GaidoSystem.Models
{
    public class HistorialER
    {
        public int HistorialERId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Ventas Netas")]
        [Column(TypeName ="decimal(18,2)")]
        public decimal VentasNetas { get; set; }

        [Display(Name = "Costos de Ventas")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostosVentas { get; set; }

        [Display(Name = "Gastos Administrativos")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GastosAdmin { get; set; }

        [Display(Name = "Gastos de Ventas")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GastosVentas { get; set; }

        [Display(Name = "Gastos de Operación")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GastosOperativos { get; set; }

        [Display(Name = "Otros Gastos")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OtrosGastos { get; set; }

        [Display(Name = "Utilidad")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Utilidad { get; set; }

        public int AnualidadERId { get; set; }

        AnualidadER anualidadER { get; set; }

        public int ModeloProyeccionId { get; set; }

        ModeloProyeccion ModeloProyeccion { get; set; }

    }
}
