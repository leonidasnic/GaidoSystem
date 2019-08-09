using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GaidoSystem.Models
{
    public class GaidoSystemContext : DbContext
    {
        public GaidoSystemContext (DbContextOptions<GaidoSystemContext> options)
            : base(options)
        {
        }

        public DbSet<GaidoSystem.Models.HistorialER> HistorialER { get; set; }
    }
}
