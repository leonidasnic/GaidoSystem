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
        [Column("decimal(18,2)")]
        public decimal VentasNetas { get; set; }

        [Display(Name = "Costos de Ventas")]
        [Column("decimal(18,2)")]
        public decimal CostosVentas { get; set; }

        [Display(Name = "Gastos Administrativos")]
        [Column("decimal(18,2)")]
        public decimal GastosAdmin { get; set; }

        [Display(Name = "Gastos de Ventas")]
        [Column("decimal(18,2)")]
        public decimal GastosVentas { get; set; }

        [Display(Name = "Gastos de Operacion")]
        [Column("decimal(18,2)")]
        public decimal GastosOperativos { get; set; }

        [Display(Name = "Otros Gastos")]
        [Column("decimal(18,2)")]
        public decimal OtrosGastos { get; set; }

        
        public decimal GetVentasNetasR()
        {
            return ((VentasNetas - CostosVentas));
        }

        public decimal GetUtilidad()
        {
            return (GetVentasNetasR()-GastosAdmin-GastosVentas-GastosOperativos-OtrosGastos);
        }

        
    }
}
