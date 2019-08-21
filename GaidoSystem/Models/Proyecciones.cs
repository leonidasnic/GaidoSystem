using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GaidoSystem.Models
{
    public class Proyecciones
    {
        public int ProyeccionesId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Ventas Netas")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProVentasNetas { get; set; }

        [Display(Name = "Costos de Ventas")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProCostosVentas { get; set; }

        [Display(Name = "Gastos Administrativos")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProGastosAdmin { get; set; }

        [Display(Name = "Gastos de Ventas")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProGastosVentas { get; set; }

        [Display(Name = "Gastos de Operación")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProGastosOperativos { get; set; }

        [Display(Name = "Otros Gastos")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProOtrosGastos { get; set; }

        public int ModeloProyeccionId { get; set; }

        [Display(Name= "Modelo Proyección")]
        public ModeloProyeccion ModeloProyeccion { get; set; }
    }
}
