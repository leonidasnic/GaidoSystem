using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GaidoSystem.Models
{
    public class ModeloProyeccion
    {
        public int ModeloProyeccionId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Ventas Netas")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal ModVentasNetas { get; set; }

        [Display(Name = "Costos de Ventas")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal ModCostosVentas { get; set; }

        [Display(Name = "Gastos Administrativos")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal ModGastosAdmin { get; set; }

        [Display(Name = "Gastos de Ventas")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal ModGastosVentas { get; set; }

        [Display(Name = "Gastos de Operación")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal ModGastosOperativos { get; set; }

        [Display(Name = "Otros Gastos")]
        [Column(TypeName = "decimal(4,2)")]
        public decimal ModOtrosGastos { get; set; }
       public List <HistorialER> HistotialesER { get; set; }
       public List <Proyecciones> ListaProyecciones { get; set; }
    }
}
