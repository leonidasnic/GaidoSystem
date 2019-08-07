using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaidoSystem.Models
{
    public class AnualidadER
    {
        public int AnualidadERId { get; set; }

        public int HistorialERId { get; set; }

        public List <HistorialER>  HistorialERs { get; set; }
    }
}
