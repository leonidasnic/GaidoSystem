using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GaidoSystem.Models;

namespace GaidoSystem.Models
{
    public class GaidoSystemContext : DbContext
    {
        public GaidoSystemContext (DbContextOptions<GaidoSystemContext> options)
            : base(options)
        {
        }

        public DbSet<GaidoSystem.Models.HistorialER> HistorialER { get; set; }

        public DbSet<GaidoSystem.Models.AnualidadER> AnualidadER { get; set; }

        public DbSet<GaidoSystem.Models.ModeloProyeccion> ModeloProyeccion { get; set; }

        public DbSet<GaidoSystem.Models.Proyecciones> Proyecciones { get; set; }
    }
}
