using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GaidoSystem.Models
{
    public class AnualidadER
    {
        public int AnualidadERId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Year { get; set; }

        [StringLength(50,ErrorMessage ="No puede ingresar mas de 50 carateres")]
        public int Notas { get; set; }

    }
}
