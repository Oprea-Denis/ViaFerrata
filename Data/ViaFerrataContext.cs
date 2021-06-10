using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ViaFerrata.Models;

namespace ViaFerrata.Data
{
    public class ViaFerrataContext : DbContext
    {
        public ViaFerrataContext (DbContextOptions<ViaFerrataContext> options)
            : base(options)
        {
        }
        public DbSet<ViaFerrata.Models.Traseu> Traseu{ get; set; }

        public DbSet<ViaFerrata.Models.Inchiriere> Inchiriere { get; set; }

        public DbSet<ViaFerrata.Models.Dificultate> Dificultate { get; set; }

        public DbSet<ViaFerrata.Models.Cerinte> Cerinte { get; set; }

        public DbSet<ViaFerrata.Models.Experienta> Experienta { get; set; }
    }
}
